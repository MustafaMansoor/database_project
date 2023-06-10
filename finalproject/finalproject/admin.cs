using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                adminviewrecord advrform = new adminviewrecord();
                advrform.Show();
                Hide();
            }
            else if (radioButton2.Checked)
            {

                society_record srform = new society_record();
                srform.Show();
                Hide();
            }
            else if (radioButton3.Checked)
            {

                superrequest superrform = new superrequest();
                superrform.Show();
                Hide();
            }
            else if (radioButton4.Checked)
            {
                addTempAdmin addtempform = new addTempAdmin();
                addtempform.Show();
                Hide();
            }
            else if (radioButton5.Checked)
            {
                Form1 f1 = new Form1();
                f1.Show();
                Close();
            } 




        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
