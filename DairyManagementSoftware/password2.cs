using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyManagementSoftware
{
    public partial class password2 : Form
    {
        public password2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;

            if (str == "qwerty")
            {
                rate_record_buffalo r1 = new rate_record_buffalo();
                r1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password");
                textBox1.Text = "";
            }
        }
    }
}
