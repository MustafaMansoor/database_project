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
    public partial class society_Inventory : Form
    {
        string name="";
        public society_Inventory(string eventname)
        {
            InitializeComponent();
            name = eventname;
        }

        private void society_Inventory_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();
                string recordinfo = "SELECT R_ID AS \"ID\", ITEM_NAME AS \"Item Name\", QUANTITY FROM record WHERE s_name = (SELECT s_name FROM society WHERE s_name = '" + name.ToString() + "')";

                OracleCommand getrecorddetails = connection.CreateCommand();
                getrecorddetails.CommandText = recordinfo;
                OracleDataReader reader = getrecorddetails.ExecuteReader();
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
