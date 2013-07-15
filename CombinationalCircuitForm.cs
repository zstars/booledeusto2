using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleDeustoTwo
{
    public partial class CombinationalCircuitForm : Form
    {
        public CombinationalCircuitForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not yet supported");
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not yet supported");
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
        /// Sets the ID of every single output. Outputs are identified by a number,
        /// starting from 1.
        /// </summary>
        private void NameOutputs()
        {
            int nextNum = 1;
            for (int i = 0; i < outputsGrid.Rows.Count; i++)
                outputsGrid.Rows[i].HeaderCell.Value = (nextNum++).ToString();
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
            
        }

    }
}
