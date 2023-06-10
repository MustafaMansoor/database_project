using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace finalproject
{
    public partial class generatesocietyreport : Form
    {
        string Name="";
        public generatesocietyreport(string eventname)
        {
            InitializeComponent();
            Name = eventname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void generatesocietyreport_Load(object sender, EventArgs e)
        {

            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                string genreport = "select * from society_report";
                OracleCommand getreportdetails = connection.CreateCommand();
                getreportdetails.CommandText = genreport;
                OracleDataReader reader = getreportdetails.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;

                dataGridView1.BackgroundColor = Color.White;

                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
