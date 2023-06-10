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
    public partial class Form1 : Form
    {

        string role = " ";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection connection = connectionclass.GetConnection();

                if (radioButton1.Checked)
                {
                    role = "admin";
                }
                else if (radioButton2.Checked)
                {
                    role = "user";
                }
                else if (radioButton3.Checked)
                {
                    role = "society";
                }
                else
                {
                    role = " ";
                }

                string username = textBox2.Text;
                string password = textBox3.Text;
                string loginSql = "select role from login where username = '" + username + "' AND password = '" + password + "'";
                OracleCommand loginEmp = connection.CreateCommand();
                loginEmp.CommandText = loginSql;
                string emprole = loginEmp.ExecuteScalar().ToString();

                if (role == "society" && emprole == "society")
                {
                    society sform = new society(username);
                    sform.Show();
                    Hide();
                }
                else if (role == "user" && emprole == "user")
                {
                    int logid = 0;
                    string getid = "select max(LoginID)+1 from Login_info";
                    OracleCommand id = connection.CreateCommand();
                    id.CommandText = getid;
                    logid = Convert.ToInt32(id.ExecuteScalar());

                    string notify = "insert into Login_info(LoginID,username, role) values(" + logid + ",'" + username.ToString() + "','" + role + "')";
                    OracleCommand insertnotify = connection.CreateCommand();
                    insertnotify.CommandText = notify;
                    insertnotify.ExecuteNonQuery();
                    connection.Close();

                    user form = new user();
                    form.Show();
                    Hide();
                }
                else if (role == "admin" && emprole == "admin")
                {
                    admin form = new admin();
                    form.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Information");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Oracle Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
