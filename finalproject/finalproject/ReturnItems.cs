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
    public partial class ReturnItems : Form
    {
        string s_name;
        public ReturnItems(string name)
        {
            InitializeComponent();
            s_name = name;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                OracleConnection connection = connectionclass.GetConnection();
            string s_name = textBox3.Text;
            string itemname = textBox1.Text;
            int quantity = int.Parse(textBox2.Text);
            string addreq = "INSERT INTO return_request (s_name, item_name, quantity_returned) VALUES ('" + s_name + "', '" + itemname + "', " + quantity + ")";
            OracleCommand returncom = connection.CreateCommand();
            returncom.CommandText = addreq;
            returncom.ExecuteNonQuery();

                MessageBox.Show("Request Added Successfully");

                connection.Close();
                this.Hide();
                society sform = new society(s_name);
                sform.Show();

            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }
    }
}
