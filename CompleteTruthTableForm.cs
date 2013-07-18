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
    public partial class CompleteTruthTableForm : Form
    {
        public CompleteTruthTableForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Takes a dynamic object with the Digital System's data,
        /// and generates the tables of this form appropriately.
        /// </summary>
        /// <param name="sys"></param>
        internal void LoadSystem(dynamic sys)
        {
            int numcols = sys["inputs"].Count;

            if (numcols == 0)
                return;


            // Populate input table. There will be one column for each input, and
            // there will be (2^num_inputs) rows, because it must cover every possible
            // combination.
            foreach (var input in sys["inputs"])
            {
                int col = this.inputsGrid.Columns.Add(input, input);
                this.inputsGrid.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            int numrows = (int)Math.Pow(2, numcols);

            for (int i = 0; i < numrows; i++)
            {
                // Create the number in binary so that we can place the inputs in order.
                string bin = Convert.ToString(i, 2);

                // Build the array to fill with.
                var rowvals = new object[numcols];
                for (int j = 0; j < numcols; j++)
                    rowvals[j] = 0;
                for (int j = 0; j < bin.Length; j++)
                    rowvals[numcols - 1 - j] = bin[bin.Length - 1 - j];

                this.inputsGrid.Rows.Add(rowvals);
            }


            // Now we will populate the outputs table. It will initially be empty.
            // The number of columns will be the same as the number of inputs, and the
            // number of rows will of course be the same as the number of rows in the
            // inputs table.
            foreach (var output in sys["outputs"])
            {
                int col = this.outputsGrid.Columns.Add(output, output);
                this.outputsGrid.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.outputsGrid.Rows.Add(numrows);

            // Initialize every cell
            foreach (DataGridViewRow row in this.outputsGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = "";
                }
            }
        }

        private void CompleteTruthTableForm_Load(object sender, EventArgs e)
        {

        }

        private void anyButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.outputsGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString() == "")
                        cell.Value = "X";
                }
            }
        }

        private void zerosButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.outputsGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString() == "")
                        cell.Value = "0";
                }
            }
        }

        private void onesButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.outputsGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString() == "")
                        cell.Value = "1";
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.outputsGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = "";
                }
            }
        }

        private void onCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            // Code here has been moved to onCellMouseUp. Otherwise, if the user clicked
            // two fast, then it would count as a double click and only one click
            // event would be fired.
        }

        private void onCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = this.outputsGrid[e.ColumnIndex, e.RowIndex];
            switch (cell.Value.ToString())
            {
                case "":
                    cell.Value = "X";
                    break;
                case "X":
                    cell.Value = "1";
                    break;
                case "1":
                    cell.Value = "0";
                    break;
                case "0":
                    cell.Value = "X";
                    break;
            }
        }
    }
}
