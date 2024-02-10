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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GymDBDataSet.Members' table. You can move, or remove it, as needed.
            this.MembersTableAdapter.Fill(this.GymDBDataSet.Members);
            DataSet1 report_ds = new DataSet1();
            string connection_string = @"Data Source=SABA\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True";

            string query = @"SELECT MemberID, FirstName, LastName, Gender, DateOfBirth, Email, Phone, JoinDate FROM  Members";

            SqlConnection conn = new SqlConnection(connection_string);
            SqlDataAdapter adptr = new SqlDataAdapter(query, conn);
            adptr.Fill(report_ds, report_ds.Tables[0].TableName);

            ReportDataSource rds = new ReportDataSource("MembersReport", report_ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
