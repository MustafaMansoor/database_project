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
    public partial class addsection : Form
    {
        public addsection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                createSection csform = new createSection();
                csform.Show();
                Close();
            }
            else if (radioButton2.Checked)
            {
                updateSection iSform = new updateSection();
                iSform.Show();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            user userform = new user();
            userform.Show();
            Close();
        }
    }
}
