using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Shualeduri1
{
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.panelmain.Controls.Count > 0) 
                this.panelmain.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelmain.Controls.Add(f);
            this.panelmain.Tag = f;
            f.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Report_Click(object sender, EventArgs e)
        {
            loadform(new Form4());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
            
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            loadform(new Form1());
        }

        private void panelside_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do You Want To exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();

            }
            else
            {
                this.Show();

            }
        }
    }
}
