using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BooleDeustoTwo
{
    public partial class CombinationalCircuitForm : Form
    {

        /// <summary>
        /// This property is meant to hold the current full digital system.
        /// The system it holds is "full" in the sense that it is well-defined
        /// and could hence, theoretically, be generated into valid VHDL code.
        /// As of now, a full system info will contain the input and output names,
        /// and the values for every output, in order. It's a JSON-serializable object, whose
        /// format is described throughout the code.
        /// TODO: We should probably make sure that CurrentSystem is set to null every time
        /// the input/output table is modified, so that the CurrentSystem always matches
        /// the one displayed.
        /// </summary>
        dynamic CurrentSystem
        {
            get;
            set;
        }

        public CombinationalCircuitForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Serializes the system to a dynamic object which can be directly
        /// serialized into JSON.
        /// </summary>
        /// <returns>Dynamic object with data to describe the system</returns>
        private dynamic SerializeSystem()
        {
            dynamic sys = new Dictionary<string, object>();
            sys["name"] = nameBox.Text;

            var inputs = new List<string>();
            int i = 0;
            foreach (DataGridViewRow row in inputsGrid.Rows)
            {
                string name;
                var val = row.Cells[0].Value;
                if (val != null)
                    name = row.Cells[0].Value.ToString();
                else
                    name = ((char)('A' + i)).ToString();

                inputs.Add(name);
                i++;
            }

            var outputs = new List<string>();
            i = 1;
            foreach (DataGridViewRow row in outputsGrid.Rows)
            {
                string name;
                var val = row.Cells[0].Value;
                if (val != null)
                    name = row.Cells[0].Value.ToString();
                else
                    name = "F" + i.ToString();
                outputs.Add(name);
                i++;
            }

            sys["inputs"] = inputs;
            sys["outputs"] = outputs;

            return sys;
        }

        /// <summary>
        /// Saves the system to a file.
        /// BooleDeusto2 files end in bd2, and are JSON-based.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BooleDeusto2 Files (*.bd2)|*.bd2";
            sfd.ShowDialog();

            string file = sfd.FileName;
            if (file != null && file.Length > 0)
            {
                dynamic sys = SerializeSystem();

                string json = SimpleJson.SerializeObject(sys);

                File.WriteAllText(file, json);
            }
        }


        /// <summary>
        /// Deserializes from a dynamic object describing the system.
        /// This method is analogue to SerializeSystem.
        /// </summary>
        /// <param name="sys">Dynamic object to extract the data from.</param>
        private void DeserializeSystem(dynamic sys)
        {
            this.nameBox.Text = sys["name"];

            inputsGrid.Rows.Clear();
            foreach (var input in sys["inputs"])
                inputsGrid.Rows.Add(input);

            outputsGrid.Rows.Clear();
            foreach (var output in sys["outputs"])
                outputsGrid.Rows.Add(output);

            outputsNumber.Value = sys["outputs"].Count;
            inputsNumber.Value = sys["inputs"].Count;
        }

        /// <summary>
        /// Loads the system from a file.
        /// BooleDeusto2 files are JSON-based.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BooleDeusto2 Files (*.bd2)|*.bd2";
            ofd.ShowDialog();

            string file = ofd.FileName;
            if (file == null || file.Length == 0)
                return;

            string json = File.ReadAllText(file);

            dynamic sys = SimpleJson.DeserializeObject(json);

            DeserializeSystem(sys);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void test_Click(object sender, EventArgs e)
        {
            inputsGrid.Rows[0].HeaderCell.Value = "A";
        }

        private void systemPropertiesTab_Click(object sender, EventArgs e)
        {

        }

        private void onInputsNumberChanged(object sender, EventArgs e)
        {
            int rows = inputsGrid.Rows.Count;
            int target = (int)inputsNumber.Value;

            if (target > rows)
            {
                inputsGrid.Rows.Add(target - rows);
                NameInputs();
            }
            else if (target < rows)
                RemoveRows(inputsGrid, rows - target);
        }

        private void onOutputsNumberChanged(object sender, EventArgs e)
        {
            int rows = outputsGrid.Rows.Count;
            int target = (int)outputsNumber.Value;

            if (target > rows)
            {
                outputsGrid.Rows.Add(target - rows);
                NameOutputs();
            }
            else if (target < rows)
                RemoveRows(outputsGrid, rows - target);
        }


        /// <summary>
        /// Sets the ID of every single input. Inputs are identified by a letter,
        /// starting from A.
        /// </summary>
        private void NameInputs()
        {
            char nextLetter = (char)'A';
            for (int i = 0; i < inputsGrid.Rows.Count; i++)
                inputsGrid.Rows[i].HeaderCell.Value = (nextLetter++).ToString();
        }

        /// <summary>
        /// Sets the ID of every single output. Outputs are identified by 'F' plus a number,
        /// starting from F1.
        /// </summary>
        private void NameOutputs()
        {
            int nextNum = 1;
            for (int i = 0; i < outputsGrid.Rows.Count; i++)
                outputsGrid.Rows[i].HeaderCell.Value = "F" + (nextNum++).ToString();
        }

        private void RemoveRows(DataGridView grid, int num)
        {
            for (int i = 0; i < num; i++ )
                grid.Rows.RemoveAt(grid.Rows.Count - 1);
        }

        private void onFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            this.nameBox.Text = "Unnamed";
        }

        private void completeTruthTableButton_Click(object sender, EventArgs e)
        {
            CompleteTruthTableForm ttf = new CompleteTruthTableForm();

            dynamic sys;
            
            // If we have the system already, we do not need to serialize it from the GUI.
            if(CurrentSystem != null)
                sys = CurrentSystem;
            else
                sys = SerializeSystem();

            if (sys["inputs"].Count == 0)
            {
                MessageBox.Show("System has not been defined yet");
                return;
            }

            ttf.LoadSystem(sys);

            ttf.ShowDialog();


            // Check whether the outputs are now set, so that we can update the system accordingly.
            if (ttf.OutputValues != null)
            {
                // We update the system
                sys["outputValues"] = ttf.OutputValues;
                CurrentSystem = sys;
            }
        }

    }
}
