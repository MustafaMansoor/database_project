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

namespace tryagain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost:1521/xe;User Id=ORACLE;Password=oracle;";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string username = textBox1.Text;
                    string lastname = textBox2.Text;
                    int id = int.Parse(textBox3.Text);
                    string password = textBox4.Text;
                    string insertSql = "insert into Student values(" + id.ToString() + ",'" + username + "','" + lastname + "','" + password + "')";
                    OracleCommand insertEmp = connection.CreateCommand();
                    insertEmp.CommandText = insertSql;
                    insertEmp.ExecuteNonQuery();
                    MessageBox.Show("Student record added successfully!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost:1521/xe;User Id=ORACLE;Password=oracle;";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    int id = int.Parse(textBox5.Text);

                    string deleteSql = "delete from student where id = " + id.ToString();
                    OracleCommand deleteEmp = connection.CreateCommand();
                    deleteEmp.CommandText = deleteSql;
                    deleteEmp.ExecuteNonQuery();
                    MessageBox.Show("Student record added successfully!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }




        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost:1521/xe;User Id=ORACLE;Password=oracle;";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string username = textBox7.Text;
                    string lastname = textBox8.Text;
                    int id = int.Parse(textBox6.Text);

                    string updateSql = "update student set firstname = '" + username + "', lastname = '" + lastname + "' where id = " + id.ToString();
                    OracleCommand updateEmp = connection.CreateCommand();
                    updateEmp.CommandText = updateSql;
                    updateEmp.ExecuteNonQuery();
                    MessageBox.Show("Student record updated successfully!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
