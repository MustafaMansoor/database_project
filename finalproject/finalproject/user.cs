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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                addsection asform = new addsection();
                asform.Show();
               Close();
            }
            else if (radioButton2.Checked)
            {

                additem atform = new additem();
                atform.Show();
               Close();
            }
            else if (radioButton4.Checked)
            {

                Form1 f1 = new Form1();
                f1.Show();
                Close();
            }
            else if (radioButton3.Checked)
            {
                manageInventory miform = new manageInventory();
                miform.Show();
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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
