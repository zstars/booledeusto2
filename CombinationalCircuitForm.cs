using Noesis.Javascript;
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

// TODO: There is a bug where changing the name of the combinational system erases the CurrentSystem.
// The system should probably only be erased when the number of inputs or outputs changes.


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
        /// It should contain items only. That is, JsonObject instead of dictionaries, and 
        /// JsonArrays instead of lists.
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
            dynamic sys = new JsonObject();
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

            var outputs = new JsonArray();
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
                // If the system is well-defined and up to date, then we use it. Otherwise we serialize the 
                // currently displayed system on the GUI, which won't have values set for the outputs.
                dynamic sys = CurrentSystem != null? CurrentSystem : SerializeSystem();

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

            // TODO: There is currently a major issue with this. The sys object isn't uniformly built, 
            // as sometimes a Dictionary is used etc. The interface to check whether a key exists seems
            // to be different. That issue will need to be solved before this can work properly.
            if (sys.ContainsKey("outputValues"))
            {
                // If we're dealing with a full system, it becomes our new CurrentSystem.
                CurrentSystem = sys;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        class SystemConsole
        {
            public void Print(string str)
            {
                Console.WriteLine(str);
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            // Initialize a context
            JavascriptContext context = new JavascriptContext();

            // Setting external parameters for the context
            context.SetParameter("console", new SystemConsole());
            context.SetParameter("message", "Hello World !");
            context.SetParameter("number", 1);

            // Script
            string script = @"
                var i;
                for (i = 0; i < 5; i++)
                    console.Print(message + ' (' + i + ')');
                number += i;
            ";

            // Running the script
            context.Run(script);

            // Getting a parameter
            Console.WriteLine("number: " + context.GetParameter("number"));
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


        /// <summary>
        /// This is the method to call whenever the inputs or outputs were changed.
        /// It means that the CurrentSystem is no longer up to date, and is thus cleared.
        /// </summary>
        private void onInputsOutputsChangeOccurred()
        {
            CurrentSystem = null;
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


        private void OnCellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // This event is probably thrown more often than we need for our purpose, but it should work fine,
            // especially on an initial stage.

            // We want to remove the CurrentSystem whenever something in the inputs or outputs has changed, because
            // it means that whatever outputs were defined for the previous system, they no longer apply.
            // Here we make sure that is indeed done. 

            this.onInputsOutputsChangeOccurred();
        }

        /// <summary>
        /// Extracts a column of outputs from the CurrentSystem.
        /// </summary>
        /// <param name="col">Column to extract. For instance, 0 to extract the first outputs column.</param>
        /// <returns></returns>
        private List<String> ExtractOutputs(int col)
        {
            // Extracts column of outputs
            var outputs = new List<String>();

            int outputNum = col;
            int i = 0;
            int n = 0;
            foreach (string output in CurrentSystem["outputValues"])
            {
                if (i % CurrentSystem["outputs"].Count == outputNum)
                    outputs.Add(output);
                i++;
            }

            return outputs;
        }

        private void sopButton_Click(object sender, EventArgs e)
        {
            // Ensure that our system is fully defined. Otherwise we
            // can't generate SOP expressions.
            if (CurrentSystem == null || !CurrentSystem.ContainsKey("outputValues"))
            {
                MessageBox.Show("You need to define the Truth Table before you can generate the SOP expressions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize a context
            JavascriptContext context = new JavascriptContext();

            // Load Source of the QM algorithm script.
            string source = File.ReadAllText("../../js/quine/src/qm.js");
            context.Run(source);

            // Setting external parameters for the context
            context.SetParameter("console", new SystemConsole());

            // Convert inputs to a comma-separated string
            string inputsStr = string.Join(",", CurrentSystem["inputs"]);

            var minterms = new List<string>();
            var dontNeeds = new List<string>();

            // To store the list of SOPs we will obtain
            var sops = new List<string>();


            // We will need to obtain a boolean equation for each output.
            for (int outputNum = 0; outputNum < CurrentSystem["outputs"].Count; outputNum++)
            {
                // Generate minterms and dontNeeds list
                int i = 0;
                foreach (string output in ExtractOutputs(outputNum))
                {
                    if (output == "1")
                        minterms.Add(i.ToString());
                    else if (output == "X")
                        dontNeeds.Add(i.ToString());
                    i++;
                }

                string mintermsStr = string.Join(",", minterms);
                string dontNeedsStr = string.Join(",", dontNeeds);


                // Script
                string script = string.Format(@"
                    var userInput = {{ inputs: '{0}', minterms: '{1}', dontNeeds: '{2}' }};
                    result = qm.getLeastPrimeImplicants( userInput );
                ", inputsStr, mintermsStr, dontNeedsStr);

                // Running the script
                context.Run(script);

                // Extract the resulting equation
                string eq = context.GetParameter("result").ToString();

                // Add the SOP we have just obtained to our list of SOPs. Also, preppend the outputName.
                sops.Add("" + CurrentSystem["outputs"][outputNum] + ": " + eq);

                //MessageBox.Show(eq);

                // Getting a parameter
                Console.WriteLine("number: " + context.GetParameter("number"));
            }


            // Open the SOP form
            SOPForm sop = new SOPForm();
            sop.SOPs = sops;
            sop.ShowDialog();
        }

    }
}
