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
    public partial class rate_record_buffalo : Form
    {
        public rate_record_buffalo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 3;

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
                int id = 4;

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
                int no = rate.update_data(id, start, end, incr, 3);

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
                int no = rate.update_data(id, start, end, incr, 4);

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

        private void rate_record_buffalo_Load(object sender, EventArgs e)
        {
            try
            {
                rate_class r1 = new rate_class();
                var tuple = r1.Fetch_rate(2);
                rate_start.Text = tuple.Item1;

                int id = 3;

                rate_class r2 = new rate_class();
                DataTable dt = new DataTable();
                dt = r2.display(id);
                dataGridView1.DataSource = dt;

                id = 4;

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
                int no = rate.update_rate(2, r);
                if (no > 0)
                {
                    MessageBox.Show("Data Updated");
                    var tuple = rate.Fetch_rate(2);
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
