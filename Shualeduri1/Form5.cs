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

namespace Shualeduri1
{
    public partial class Form5 : Form
    {
        static readonly string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True");
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True"))
                {
                    conn.Open();

                    // Use parameterized query to avoid SQL injection
                    string sql = "INSERT INTO [dbo].[Login] ([username], [password]) VALUES (@Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Use parameters to pass values safely
                        cmd.Parameters.AddWithValue("@Username", Username.Text);
                        cmd.Parameters.AddWithValue("@Password", Password.Text); // Assuming Password is a TextBox

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("You Have Been Registered Successfully");

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Button_exit_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }
    }
}
