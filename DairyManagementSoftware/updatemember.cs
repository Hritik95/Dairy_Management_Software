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
    public partial class updatemember : Form
    {
        public updatemember()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            inp_name.Clear();
            inp_address.Clear();
            inp_number.Clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(inp_id.Text);
                String name = inp_name.Text;
                String address = inp_address.Text;
                String phone = inp_number.Text;

                member_class m1 = new member_class();
                int no = m1.updatedata(id, name, address, phone);

                if (no > 0)
                {
                    MessageBox.Show("Data Updated");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(inp_id.Text);
                member_class m6 = new member_class();
                var tuple = m6.Fetch_data(id);

                inp_name.Text = tuple.Item1;
                inp_address.Text = tuple.Item2;
                inp_number.Text = tuple.Item3;
            } catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
