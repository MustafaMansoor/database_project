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
    public partial class itemrequest : Form
    {
        string name;
        public itemrequest(string eventname)
        {
            InitializeComponent();
            name = eventname;
        }

        private void itemrequest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = textBox1.Text;
            string quantity = textBox2.Text;
            

            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                string request = "INSERT INTO requests (s_name, item_name, quantity_requested) VALUES ('" + name.ToString() + "', '" + item + "', '" + quantity + "')";
                OracleCommand insertrequest = connection.CreateCommand();
                insertrequest.CommandText = request;
                insertrequest.ExecuteNonQuery();

                MessageBox.Show("Request Added Successfully");

                connection.Close();
                this.Hide();
                society sform = new society(name);
                sform.Show();

            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            society sform = new society(name);
            sform.Show();
            Close();
        }
    }
}
