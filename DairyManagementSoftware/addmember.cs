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
    public partial class addmember : Form
    {
        public addmember()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            id_inp.Clear();
            name_inp.Clear();
            address_inp.Clear();
            mobile_inp.Clear();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(id_inp.Text);
                String name = name_inp.Text;
                String address = address_inp.Text;
                String ph_no = mobile_inp.Text;
                String date = date_inp.Value.ToString("MM-dd-yyyy");

                member_class m1 = new member_class();

                int no = m1.addData(id, name, address, ph_no, date);

                if (no > 0)
                {
                    MessageBox.Show("Data Added");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }

            } catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
    }
}
