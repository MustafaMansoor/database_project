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
    public partial class society_record : Form
    {
        public society_record()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();
                string societyname = textBox1.Text;
                string query = "SELECT s.s_name AS Society, s.s_mentor AS Mentor, s.s_president AS President, r.item_name AS Item, r.quantity AS Quantity FROM society s JOIN record r ON s.s_name = r.s_name WHERE s.s_name = '" + societyname + "'";
                OracleCommand getsociety = connection.CreateCommand();
                getsociety.CommandText = query;
                OracleDataReader reader = getsociety.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.FillWeight = 1;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void society_record_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin form = new admin();
            form.Show();
            Close();
        }
    }
}
