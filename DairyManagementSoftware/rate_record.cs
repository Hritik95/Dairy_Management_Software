using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DairyManagementSoftware
{
    public partial class rate_record : Form
    {
        public rate_record()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 1;

                rate_class r2 = new rate_class();
                DataTable dt = new DataTable();
                dt = r2.display(id);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 2;

                rate_class r2 = new rate_class();
                DataTable dt = new DataTable();
                dt = r2.display(id);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                float start = float.Parse(textBox2.Text);
                float end = float.Parse(textBox3.Text);
                float incr = float.Parse(textBox4.Text);

                rate_class rate = new rate_class();
                int no = rate.update_data(id, start, end, incr, 1);

                if (no > 0)
                {
                    MessageBox.Show("Data Updated");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox5.Text);
                float start = float.Parse(textBox6.Text);
                float end = float.Parse(textBox7.Text);
                float incr = float.Parse(textBox8.Text);

                rate_class rate = new rate_class();
                int no = rate.update_data(id, start, end, incr, 2);

                if (no > 0)
                {
                    MessageBox.Show("Data Updated");
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rate_record_Load(object sender, EventArgs e)
        {
            try
            {
                rate_class r1 = new rate_class();
                var tuple = r1.Fetch_rate(1);
                rate_start.Text = tuple.Item1;

                int id = 1;

                rate_class r2 = new rate_class();
                DataTable dt = new DataTable();
                dt = r2.display(id);
                dataGridView1.DataSource = dt;

                id = 2;

                dt = r2.display(id);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                rate_class rate = new rate_class();
                float r = float.Parse(textBox9.Text);
                int no = rate.update_rate(1, r);
                if (no > 0)
                {
                    MessageBox.Show("Data Updated");
                    var tuple = rate.Fetch_rate(1);
                    rate_start.Text = tuple.Item1;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
