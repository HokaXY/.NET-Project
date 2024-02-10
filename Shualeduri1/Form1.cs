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
    public partial class Form1 : Form
    {
        static readonly string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                string selectStr = "select * from Members";
                SqlCommand cmd = new SqlCommand(selectStr, con);
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("updatemembers", con, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter id = new SqlParameter()
                    {
                        ParameterName = "@MemberID",
                        DbType = DbType.Int32,
                        Value = UserID.Text,
                        Direction = ParameterDirection.Input,
                    };

                    SqlParameter fs = new SqlParameter()
                    {
                        ParameterName = "@FirstName",
                        DbType = DbType.String,
                        Value = FirstName.Text,
                        Direction = ParameterDirection.Input,
                    };

                    SqlParameter ls = new SqlParameter()
                    {
                        ParameterName = "@LastName",
                        DbType = DbType.String,
                        Value = LastName.Text,
                        Direction = ParameterDirection.Input,
                    };

                    SqlParameter email = new SqlParameter()
                    {
                        ParameterName = "@Email",
                        DbType = DbType.String,
                        Value = Email.Text,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter phone = new SqlParameter()
                    {
                        ParameterName = "@Phone",
                        DbType = DbType.String,
                        Value = Phone.Text,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter gender = new SqlParameter()
                    {
                        ParameterName = "@Gender",
                        DbType = DbType.String,
                        Value = Gender.Text,
                        Direction = ParameterDirection.Input,
                    };


                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(fs);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(ls);
                    cmd.Parameters.Add(phone);
                    cmd.Parameters.Add(gender);

                    cmd.ExecuteNonQuery();

                    string selectStr = "select * from Members";
                    SqlCommand cmd1 = new SqlCommand(selectStr, con, transaction);
                    cmd1.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);

                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error Message", MessageBoxButtons.OK);

                }




            }

        }

        private void insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("insertMembers", con, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter fs = new SqlParameter()
                    {
                        ParameterName = "@FirstName",
                        DbType = DbType.String,
                        Value = FirstName.Text,
                        Direction = ParameterDirection.Input,
                    };

                    SqlParameter ls = new SqlParameter()
                    {
                        ParameterName = "@LastName",
                        DbType = DbType.String,
                        Value = LastName.Text,
                        Direction = ParameterDirection.Input,
                    };

                    SqlParameter email = new SqlParameter()
                    {
                        ParameterName = "@Email",
                        DbType = DbType.String,
                        Value = Email.Text,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter phone = new SqlParameter()
                    {
                        ParameterName = "@Phone",
                        DbType = DbType.String,
                        Value = Phone.Text,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter gender = new SqlParameter()
                    {
                        ParameterName = "@Gender",
                        DbType = DbType.String,
                        Value = Gender.Text,
                        Direction = ParameterDirection.Input,
                    };

                    SqlParameter dateofbirth = new SqlParameter()
                    {
                        ParameterName = "@DateOfBirth",
                        DbType = DbType.Date,
                        Value = DateOfBirth.Text,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter joindate = new SqlParameter()
                    {
                        ParameterName = "@JoinDate",
                        DbType = DbType.Date,
                        Value = JoinDate.Text,
                        Direction = ParameterDirection.Input,
                    };


                    cmd.Parameters.Add(fs);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(ls);
                    cmd.Parameters.Add(phone);
                    cmd.Parameters.Add(gender);
                    cmd.Parameters.Add(dateofbirth);
                    cmd.Parameters.Add(joindate);

                    cmd.ExecuteNonQuery();

                    string selectStr = "select * from Members";
                    SqlCommand cmd1 = new SqlCommand(selectStr, con, transaction);
                    cmd1.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);

                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error Message", MessageBoxButtons.OK);

                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("deletemember", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter delid = new SqlParameter
                {
                    ParameterName = "@id",
                    DbType = DbType.Int32,
                    Value = int.Parse(deleteTextBox.Text),
                    Direction = ParameterDirection.Input,
                };
                cmd.Parameters.Add(delid);

                cmd.ExecuteNonQuery();



            }
        }

        async private void countMen_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {

                await con.OpenAsync();

                string countStr = "waitfor delay '00:00:05'; select count(MemberID) from Members where Gender='Man'";
                SqlCommand cmd = new SqlCommand(countStr, con);

                int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                label9.Text = Convert.ToString(count);
            }
        }

        private void deleteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
