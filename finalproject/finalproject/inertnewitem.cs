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
    public partial class inertnewitem : Form
    {
        public inertnewitem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            user userform = new user();
            userform.Show();
            Close();
        }

        private void inertnewitem_Load(object sender, EventArgs e)
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
                string item = textBox1.Text;
                int sec = int.Parse(textBox2.Text);
                int itemId = 0;
                int quantity = 0;
                quantity = int.Parse(textBox3.Text);
                int id = 0;
                string inventid = "select max(INVENTORY_ID)+1 from inventory";
                OracleCommand getinventory = connection.CreateCommand();
                getinventory.CommandText = inventid;
                id = Convert.ToInt32(getinventory.ExecuteScalar());
                string itemid = "select max(ITEM_ID) + 1 from item";
                OracleCommand getid = connection.CreateCommand();
                getid.CommandText = itemid;
                itemId = Convert.ToInt32(getid.ExecuteScalar());
                string insertitem = "insert into item(ITEM_ID, ITEM_NAME, SECTION_ID) values (" + itemId + ", '" + item.Replace("'", "''") + "', " + sec + ")";
                string inventory = "insert into inventory(INVENTORY_ID,ITEM_ID,SECTION_ID,QUANTITY) values(" + id + ", '" + itemId + "', " + sec + "," + quantity + ")";
                OracleCommand itemsec = connection.CreateCommand();
                itemsec.CommandText = insertitem;
                itemsec.ExecuteNonQuery();
                itemsec.CommandText = inventory;
                itemsec.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item added Successfully ");
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



        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
