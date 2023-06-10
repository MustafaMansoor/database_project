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
    public partial class addTempAdmin : Form
    {
        public addTempAdmin()
        {
            InitializeComponent();
        }

        private void addTempAdmin_Load(object sender, EventArgs e)
        {
            try
            {

                OracleConnection connection = connectionclass.GetConnection();
            string users = "select username from Login where role = 'user'";
            OracleCommand getusers = connection.CreateCommand();
            getusers.CommandText = users;
            OracleDataReader reader = getusers.ExecuteReader();
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

                string username = textBox1.Text;
            OracleConnection connection = connectionclass.GetConnection();
            string users = "update Login set role = 'admin' where username = '"+username.ToString()+"'";
            OracleCommand setusers = connection.CreateCommand();
            setusers.CommandText = users;
            setusers.ExecuteNonQuery();
                connection.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
}

        private void button2_Click(object sender, EventArgs e)
        {

            admin form = new admin();
            form.Show();
            Close();

        }
    }
}
