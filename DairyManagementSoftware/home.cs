using System;
using System.Data;
using System.Windows.Forms;

namespace DairyManagementSoftware
{
    public partial class home : Form
    {



        public home()
        {
            InitializeComponent();
        }



        private void add_mem_btn_Click(object sender, EventArgs e)
        {
            addmember a1 = new addmember();
            a1.ShowDialog();
        }

        private void update_mem_btn_Click(object sender, EventArgs e)
        {
            updatemember a2 = new updatemember();
            a2.ShowDialog();
        }

        private void del_mem_btn_Click(object sender, EventArgs e)
        {
            deletemember a3 = new deletemember();
            a3.ShowDialog();
        }

        private void show_btn_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(show_id.Text);

                member_class m4 = new member_class();
                DataTable dt = new DataTable();
                dt = m4.display(id);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Syntax");
            }
            
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void display_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id_inp.Text);
                member_class m5 = new member_class();
                var tuple = m5.Fetch_data(id);
                if (tuple.Item3 == "-1")
                {
                    MessageBox.Show("Record not found");
                    dis1.Text = "";
                    dis2.Text = "";
                }
                else
                {
                    dis1.Text = tuple.Item1;
                    dis2.Text = tuple.Item3;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id_inp.Text);
                String date = coll_date.Value.ToString("MM-dd-yyyy");

                String milk_type;
                if (radioButtoncow.Checked)
                {
                    milk_type = "Cow Milk";
                }
                else
                {
                    milk_type = "Buffalo Milk";
                }

                String session;
                if (radioButtonmor.Checked)
                {
                    session = "Morning";
                }
                else
                {
                    session = "Evening";
                }

                int tot_milk = Convert.ToInt32(tot_milk_inp.Text);
                int fat = Convert.ToInt32(fat_inp.Text);
                int snf = Convert.ToInt32(snf_inp.Text);
                int tot_amt = Convert.ToInt32(tot_amt_inp.Text);

                if (radioButtonbuffalo.Checked || radioButtoncow.Checked && radioButtonmor.Checked || radioButtoneven.Checked)
                {
                    record_class r1 = new record_class();
                    int no = r1.addData(id, date, milk_type, session, tot_milk, fat, snf, tot_amt);

                    if (no > 0)
                    {
                        MessageBox.Show("Data Added");
                        clear();
                        id_inp.Clear();
                        dis1.Text = "";
                        dis2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter All Fields");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            radioButtonbuffalo.Checked = false;
            radioButtoncow.Checked = false;
            radioButtoneven.Checked = false;
            radioButtonmor.Checked = false;
            tot_milk_inp.Clear();
            tot_amt_inp.Clear();
            fat_inp.Clear();
            snf_inp.Clear();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id_inp_sale.Text);
                member_class m6 = new member_class();
                var tuple = m6.Fetch_data(id);
                if (tuple.Item3 == "-1")
                {
                    MessageBox.Show("Record not found");
                    dis11.Text = "";
                    dis12.Text = "";
                }
                else
                {
                    dis11.Text = tuple.Item1;
                    dis12.Text = tuple.Item3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_sales_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id_inp_sale.Text);
                String date = datesalesinp.Value.ToString("MM-dd-yyyy");
                String selection = comboBox1.Text.ToString();
                int qnt = Convert.ToInt32(qnt_inp.Text);
                int price = Convert.ToInt32(price_inp.Text);
                int tot_amt = Convert.ToInt32(tot_amt_sales.Text);

                sales_class s1 = new sales_class();
                int no = s1.insertdata(id, date, selection, qnt, price, tot_amt);

                if (no > 0)
                {
                    MessageBox.Show("Data Added");
                    clear_sales();
                    dis11.Text = "";
                    dis12.Text = "";
                    id_inp_sale.Clear();
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

        public void clear_sales()
        {
            comboBox1.Text = "";
            qnt_inp.Clear();
            price_inp.Clear();
            tot_amt_sales.Clear();
        }

        private void clearbtn_sales_Click(object sender, EventArgs e)
        {
            clear_sales();
        }

        private void coll_record_btn_Click(object sender, EventArgs e)
        {
            collection_display c1 = new collection_display();
            c1.ShowDialog();
        }

        private void item_sales_record_Click(object sender, EventArgs e)
        {
            sales_display s1 = new sales_display();
            s1.ShowDialog();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(id_inp_bill.Text);
                String date1 = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                String date2 = dateTimePicker2.Value.ToString("MM-dd-yyyy");

                record_class r1 = new record_class();
                String tot_col = r1.sum_coll(id, date1, date2);

                if(tot_col == "")
                {
                    tot_col = "0";
                }

                if (tot_col == "error")
                {
                    MessageBox.Show("Record Not Found");
                }
                else
                {
                    bill_col_label.Text = tot_col;
                }


                sales_class s2 = new sales_class();
                String tot_sales = s2.sum_sales(id, date1, date2);

                if (tot_sales == "")
                {
                    tot_sales = "0";
                }

                if (tot_sales == "error")
                {
                    MessageBox.Show("Record Not Found");
                }
                else
                {
                    sales_bill_label.Text = tot_sales;
                }


                int num1 = int.Parse(tot_col);
                int num2 = int.Parse(tot_sales);

                int grand = num1 - num2;
                grand_total.Text = grand.ToString();


            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void sales_bill_label_Click(object sender, EventArgs e)
        {

        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            print_bill pb = new print_bill();
            pb.col_total = bill_col_label.Text;
            pb.sales_total = sales_bill_label.Text;
            pb.grand_total = grand_total.Text;
            pb.mem_id = Convert.ToInt32(id_inp_bill.Text);
            pb.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
