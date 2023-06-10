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
    public partial class superrequest : Form
    {
        public superrequest()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string req = textBox1.Text;
                OracleConnection connection = connectionclass.GetConnection();

                string reqcommand = "select REQUEST_ID As ID , S_NAME AS Name , ITEM_NAME AS Items, QUANTITY_REQUESTED AS Quantity, APPROVAL_STATUS AS Status from requests where S_NAME = '" + req + "'";
                OracleCommand getreq = connection.CreateCommand();
                getreq.CommandText = reqcommand;
                OracleDataReader reader = getreq.ExecuteReader();
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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string checkopt = "";
                if (radioButton1.Checked)
                {
                    checkopt = "accepted";
                }
                else if (radioButton2.Checked)
                {
                    checkopt = "rejected";
                }

                int reqid;
                if (!int.TryParse(textBox2.Text, out reqid))
                {
                    throw new Exception("Invalid request ID.");
                }

                OracleConnection connection = connectionclass.GetConnection();
                string updateRequest = "UPDATE requests SET approval_status = '" + checkopt + "' WHERE request_id = " + reqid;
                OracleCommand setUpdatedRequest = connection.CreateCommand();
                setUpdatedRequest.CommandText = updateRequest;
                setUpdatedRequest.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Request updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void superrequest_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin form = new admin();
            form.Show();
            Close();
        }
    }
}
