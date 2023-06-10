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
    public partial class manageInventory : Form
    {
        public manageInventory()
        {
            InitializeComponent();
        }

        private void manageInventory_Load(object sender, EventArgs e)
        {

            try
            {
                OracleConnection connection = connectionclass.GetConnection();


                string Tracksec = "SELECT section.SECTION_ID AS ID , section.SECTION_NAME,item.ITEM_ID,item.ITEM_NAME,inventory.quantity AS Quantity FROM section INNER JOIN item ON section.SECTION_ID = item.SECTION_ID INNER JOIN inventory on item.ITEM_ID = inventory.ITEM_ID ORDER BY section.SECTION_ID, item.item_id";
                OracleCommand getsecreport = connection.CreateCommand();
                getsecreport.CommandText = Tracksec;
                OracleDataReader reader = getsecreport.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;

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
                int itemid = int.Parse(textBox1.Text);
                int quantity = int.Parse(textBox2.Text);
                int oldquantity = 0;

                OracleConnection connection = connectionclass.GetConnection();
         
                string oldquant = "select quantity from inventory where ITEM_ID = " + itemid;
                OracleCommand getoldquant = connection.CreateCommand();
                getoldquant.CommandText = oldquant;
                oldquantity = Convert.ToInt32(getoldquant.ExecuteScalar());

                string addinvet = "update inventory set quantity = " + (oldquantity + quantity) + " where ITEM_ID = " + itemid;
                OracleCommand updateinvent = connection.CreateCommand();
                updateinvent.CommandText = addinvet;
                updateinvent.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Item added Successfully in inventory");

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


        private void button2_Click(object sender, EventArgs e)
        {
            user userform = new user();
            userform.Show();
            Close();
        }
    }
    }
