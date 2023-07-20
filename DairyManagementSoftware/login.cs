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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string inp = text_inp.Text;

                if (inp == "admin")
                {
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    home h1 = new home();
                    h1.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Wrong Password");
                    text_inp.Clear();
                    text_inp.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
