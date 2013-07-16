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

            foreach (var input in sys["inputs"])
            {
                this.inputsGrid.Columns.Add(input, input);
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

        }
    }
}
