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
    public partial class createSection : Form
    {
        public createSection()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            user userform = new user();
            userform.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();
                string secname = textBox1.Text;
                int sectionId = 0;
                string secid = "select max(SECTION_ID) + 1 from section";
                OracleCommand getid = connection.CreateCommand();
                getid.CommandText = secid;
                sectionId = Convert.ToInt32(getid.ExecuteScalar());
                string sec = "insert into section(SECTION_ID, SECTION_NAME) values (" + sectionId + ",'" + secname + "')";
                OracleCommand createsec = connection.CreateCommand();
                createsec.CommandText = sec;
                createsec.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Section created Successfully ");
                user userform = new user();
                userform.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void createSection_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                string Tracksec = "select Section_ID AS ID , SECTION_NAME AS Name from section order by SECTION_ID";
                OracleCommand getsecreport = connection.CreateCommand();
                getsecreport.CommandText = Tracksec;
                OracleDataReader reader = getsecreport.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.FillWeight = 1;
                }
                dataGridView1.BackgroundColor = Color.White;

                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
