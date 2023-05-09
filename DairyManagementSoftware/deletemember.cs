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
    public partial class deletemember : Form
    {
        public deletemember()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(inp_id.Text);

                member_class m1 = new member_class();
                int no = m1.deletedata(id);

                if (no > 0)
                {
                    MessageBox.Show("Data Deleted");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
