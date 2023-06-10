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
    public partial class updateitem : Form
    {
        public updateitem()
        {
            InitializeComponent();
        }

        private void updateitem_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                string Tracksec = "select * from userdata";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            user userform = new user();
            userform.Show();
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {


                OracleConnection connection = connectionclass.GetConnection();
                string oldname = textBox1.Text;
                string newname = textBox2.Text;
                string update = "update item set ITEM_NAME = '" + newname + "' where ITEM_NAME = '" + oldname + "'";
                OracleCommand itemsec = connection.CreateCommand();
                itemsec.CommandText = update;
                itemsec.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item updated Successfully ");
                user userform = new user();
                userform.Show();
                Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Oracle Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
