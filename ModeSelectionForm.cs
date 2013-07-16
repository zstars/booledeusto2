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
    public partial class ModeSelectionForm : Form
    {
        public ModeSelectionForm()
        {
            InitializeComponent();
        }

        private void ModeSelectionForm_Load(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void logoCntrl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BooleDeusto2 Prototype v0.1");
        }

        private void ccButton_Click(object sender, EventArgs e)
        {
            var form = new CombinationalCircuitForm();
            form.Show(null);
            this.Hide(); // Find which is the proper way to do this
        }


    }
}
