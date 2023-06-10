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
    public partial class updateSection : Form
    {
        public updateSection()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            user userform = new user();
            userform.Show();
            Close();
        }

        private void updateSection_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                string Tracksec = "select * from section order by SECTION_ID";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                int secid = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string update = "update section set SECTION_NAME = '" + name + "' where SECTION_ID = " + secid;
                OracleCommand updatesec = connection.CreateCommand();
                updatesec.CommandText = update;
                updatesec.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Section updated Successfully ");
                user userform = new user();
                userform.Show();
                Close();


                connection.Close();
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
