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
            dataGridView1.Rows[0].HeaderCell.Value = "A";
        }
    }
}
