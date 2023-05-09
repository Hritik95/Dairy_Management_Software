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
    public partial class sales_display : Form
    {
        public sales_display()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id_inp.Text);

                sales_class s1 = new sales_class();
                DataTable dt = new DataTable();
                dt = s1.display(id);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Syntax");
            }
        }
    }
}
