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
    public partial class society : Form
    {
        string name = "";
        public society(string societyname)
        {
            InitializeComponent();
            name = societyname;

        }

        private void society_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                EventDetails form = new EventDetails(name);
                form.Show();
                Hide();
            }
            else if (radioButton2.Checked)
            {
                memberinfo form = new memberinfo(name);
                form.Show();
                Hide();
            }
            else if (radioButton3.Checked)
            {
                society_Inventory form = new society_Inventory(name);
                form.Show();
                Hide();

            }
            else if (radioButton4.Checked)
            {

                itemrequest form = new itemrequest(name);
                form.Show();
                Hide();
            }
            else if (radioButton5.Checked)
            {

                TrackRequest trform = new TrackRequest(name);
                trform.Show();
                Hide();
            }
            else if (radioButton6.Checked)
            {
                Form1 f1 = new Form1();
                f1.Show();
                Close();

            }
            else if (radioButton7.Checked)
            {
                ReturnItems riform = new ReturnItems(name);
                riform.Show();
                Close();
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
        }
    }
}
