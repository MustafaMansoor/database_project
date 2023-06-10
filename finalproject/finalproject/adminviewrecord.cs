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
    public partial class adminviewrecord : Form
    {
        public adminviewrecord()
        {
            InitializeComponent();
        }
        private void adminviewrecord_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();
                string getquantity = "SELECT get_total_quantity() FROM dual";
                OracleCommand gettotal = connection.CreateCommand();
                gettotal.CommandText = getquantity;
                string result = gettotal.ExecuteScalar().ToString();
                textBox1.Text = result;

                string SecItems = "SELECT section.section_name, item.item_name, inventory.quantity FROM section JOIN item ON section.section_id = item.section_id JOIN inventory ON item.item_id = inventory.item_id";
                OracleCommand getSecItems = connection.CreateCommand();
                getSecItems.CommandText = SecItems;
                OracleDataReader reader = getSecItems.ExecuteReader();

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

                string checktempTable = "BEGIN :result := checkNotify(); END;";
                OracleCommand notifyResult = connection.CreateCommand();
                notifyResult.CommandText = checktempTable;

                OracleParameter resultParam = new OracleParameter("result", OracleDbType.Decimal);
                resultParam.Direction = ParameterDirection.ReturnValue;
                notifyResult.Parameters.Add(resultParam);

                notifyResult.ExecuteNonQuery();

                string rowsAffected = notifyResult.Parameters["result"].Value.ToString();
                textBox2.Text = rowsAffected;
                string getnotify = "select * from notifyview";
                notifyResult.CommandText = getnotify;

                reader = notifyResult.ExecuteReader();
                DataTable dataTable2 = new DataTable();
                dataTable2.Load(reader);
                dataGridView2.DataSource = dataTable2;

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.FillWeight = 1;
                }
                dataGridView2.BackgroundColor = Color.White;

                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin from = new admin();
            from.Show();
            Close();
        }
    }
}
