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
    public partial class SOPForm : Form
    {
        public List<string> SOPs { get; set; }

        public SOPForm()
        {
            InitializeComponent();
        }

        

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SOPForm_Load(object sender, EventArgs e)
        {
            foreach (string sop in SOPs)
            {
                listBox.Items.Add(sop);
            }
        }
    }
}
