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
    public partial class additem : Form
    {
        public additem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                inertnewitem intform = new inertnewitem();
                intform.Show();
                Close();
            }
            else if (radioButton2.Checked)
            {
                updateitem uifrom = new updateitem();
                uifrom.Show();
                Close();
            }
            else if (radioButton3.Checked)
            {
                Deleteitem diItem = new Deleteitem();
                diItem.Show();
                Close();
            }
        }
    }
}
