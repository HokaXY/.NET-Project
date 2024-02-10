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
    public partial class Form2 : Form
    {
        static readonly string ConString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;
            
            
            using (SqlConnection con = new SqlConnection(ConString)) ;
            try
            {
                string lquerry = "SELECT * FROM Login WHERE username = '"+txt_username.Text+"'AND password ='"+txt_password.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(lquerry, conn);


                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    Form3 form = new Form3();
                    form.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Credentials","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                    txt_username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }

        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
        }

        private void Button_exit_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }


    }
}
