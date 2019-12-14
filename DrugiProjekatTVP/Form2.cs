using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugiProjekatTVP
{
    public partial class Form2 : Form
    {
        private string uzorak;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string uzorak)
        {
            InitializeComponent();
            this.uzorak = uzorak;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblUpitnik.Text = uzorak;
        }

        private void btnDa_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btnNe_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }
    }
}
