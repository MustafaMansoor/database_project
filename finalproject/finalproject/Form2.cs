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
    public partial class EventDetails : Form
    {
        string name;
        public EventDetails(string societyname)
        {
            InitializeComponent();
            name = societyname;
        }

        private void EventDetails_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();
                string eventinfo = "SELECT EVENT_NAME AS \"Event Name\", START_DATE AS \"Start\", END_DATE AS \"End\" FROM event WHERE s_name = '" + name.ToString() + "'";

                OracleCommand geteventdetails = connection.CreateCommand();
                geteventdetails.CommandText = eventinfo;
                OracleDataReader reader = geteventdetails.ExecuteReader();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            string text = "Event Details for society "+ name;
            label1.Text = text;
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            society sform = new society(name);
            sform.Show();
            Close();
        }
    }
}
