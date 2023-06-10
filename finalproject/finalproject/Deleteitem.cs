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
    public partial class Deleteitem : Form
    {
        public Deleteitem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user userform=new user();
            userform.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();
                string itemname = textBox1.Text;
            int itemid = int.Parse(textBox3.Text);
            string delfrominvent ="delete from inventory where item_id = "+itemid;
            string delfromitem = "delete from item where item_id = " + itemid;
                OracleCommand itemsec = connection.CreateCommand();
                itemsec.CommandText = delfrominvent;
                itemsec.ExecuteNonQuery();
                itemsec.CommandText = delfromitem;
                itemsec.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item deleted Successfully ");
                user userform = new user();
                userform.Show();



                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }




        }

        private void Deleteitem_Load(object sender, EventArgs e)
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
    }
}
