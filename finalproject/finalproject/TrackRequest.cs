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
    public partial class TrackRequest : Form
    {
        string name;
        public TrackRequest(string username)
        {
            InitializeComponent();
            name = username;
        }

        private void TrackRequest_Load(object sender, EventArgs e)
        {

            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                string TrackRequest = "select * from requests where s_name = '"+ name + "'";
                OracleCommand getrequestreport = connection.CreateCommand();
                getrequestreport.CommandText = TrackRequest;
                OracleDataReader reader = getrequestreport.ExecuteReader();
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

        private void button1_Click(object sender, EventArgs e)
        {
            society sform = new society(name);
            sform.Show();
            Close();
        }
    }
    }

