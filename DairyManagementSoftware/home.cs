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

                float tot_milk = float.Parse(tot_milk_inp.Text);
                float fat = float.Parse(fat_inp.Text);
                float snf = float.Parse(snf_inp.Text);
                float rate = float.Parse(rate_inp.Text);
                float tot_amt = float.Parse(tot_amt_inp.Text);

                if (radioButtonbuffalo.Checked || radioButtoncow.Checked && radioButtonmor.Checked || radioButtoneven.Checked)
                {
                    record_class r1 = new record_class();
                    int no = r1.addData(id, date, milk_type, session, tot_milk, fat, snf, rate, tot_amt);

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
            rate_inp.Clear();
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


                float num1 = float.Parse(tot_col);
                float num2 = float.Parse(tot_sales);

                float grand = num1 - num2;
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
            pb.date1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            pb.date2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            pb.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = -1;

                member_class m4 = new member_class();
                DataTable dt = new DataTable();
                dt = m4.display(id);
                dataGridView1.DataSource = dt;
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
                rate_class r1 = new rate_class();

                float f1 = float.Parse(fat_inp.Text);
                float f2 = float.Parse(snf_inp.Text);

                if (radioButtoncow.Checked == false && radioButtonbuffalo.Checked == false)
                {
                    MessageBox.Show("Please Select Milk Type");
                }


                if (radioButtoncow.Checked)
                {
                    var tuple = r1.Fetch_rate(1);
                    float int_rate = Convert.ToSingle(tuple.Item1);
                    float fat_rate = getratefat(int_rate, f1);

                    if(fat_rate == 0)
                    {
                        MessageBox.Show("Fat value out of Range");
                        rate_inp.Text = "";
                    }
                    else
                    {
                        float rate = getrate(fat_rate, f2);
                        if(rate == 0)
                        {
                            MessageBox.Show("Snf value out of range");
                            rate_inp.Text = "";
                        }
                        else
                        {
                            rate_inp.Text = rate.ToString();
                        }
                        
                    }

                   
                }
                else if (radioButtonbuffalo.Checked)
                {
                    var tuple = r1.Fetch_rate(2);
                    float int_rate = Convert.ToSingle(tuple.Item1);
                    float fat_rate = getratefat2(int_rate, f1);

                    if (fat_rate == 0)
                    {
                        MessageBox.Show("Fat value out of Range");
                        rate_inp.Text = "";
                    }
                    else
                    {
                        float rate = getrate2(fat_rate, f2);
                        if (rate == 0)
                        {
                            MessageBox.Show("Snf value out of range");
                            rate_inp.Text = "";
                        }
                        else
                        {
                            rate_inp.Text = rate.ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            password1 p1 = new password1();
            p1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                float rate = float.Parse(rate_inp.Text);
                float milk = float.Parse(tot_milk_inp.Text);
                float tot = rate * milk;
                tot_amt_inp.Text = Convert.ToString(tot);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        float getratefat(float i,float fat)//i = initial amount fat = fat entered on screen by user
        {
            try
            {
                rate_class r1 = new rate_class();
                var tuple = r1.Fetch_data_fat(1);
                float a1 = float.Parse(tuple.Item1), b1 = float.Parse(tuple.Item2), c1 = float.Parse(tuple.Item3); // a = from b = to c = increment

                tuple = r1.Fetch_data_fat(2);
                float a2 = float.Parse(tuple.Item1), b2 = float.Parse(tuple.Item2), c2 = float.Parse(tuple.Item3);//a1, a2, ....  5 entries in database

                tuple = r1.Fetch_data_fat(3);
                float a3 = float.Parse(tuple.Item1), b3 = float.Parse(tuple.Item2), c3 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_fat(4);
                float a4 = float.Parse(tuple.Item1), b4 = float.Parse(tuple.Item2), c4 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_fat(5);
                float a5 = float.Parse(tuple.Item1), b5 = float.Parse(tuple.Item2), c5 = float.Parse(tuple.Item3);
                float j;

                if (fat < a1 || fat > b5)
                {
                    return 0;
                }

                if (fat > b1)
                {
                    i = i + ((b1 - a1) * c1 * 10);
                }
                else
                {
                    i = i + ((fat - a1) * c1 * 10);
                    return i;
                }


                if (fat > b2)
                {
                    i = i + ((b2 - a2) * c2 * 10);
                }
                else
                {
                    i = i + ((fat - a2) * c2 * 10);
                    return i;
                }

                if (fat > b3)
                {
                    i = i + ((b3 - a3) * c3 * 10);
                }
                else
                {
                    i = i + ((fat - a3) * c3 * 10);
                    return i;
                }

                if (fat > b4)
                {
                    i = i + ((b4 - a4) * c4 * 10);
                }
                else
                {
                    i = i + ((fat - a4) * c4 * 10);
                    return i;
                }

                if (fat > b5)
                {
                    i = i + ((b5 - a5) * c5 * 10);
                }
                else
                {
                    i = i + ((fat - a5) * c5 * 10);
                    return i;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        float getrate(float rate,float snf)//same as above rate = initail rate got from fat.    snf = snf entered by user 
        {
            try
            {
                rate_class r1 = new rate_class();
                var tuple = r1.Fetch_data_snf(1);
                float a1 = float.Parse(tuple.Item1), b1 = float.Parse(tuple.Item2), c1 = float.Parse(tuple.Item3);// a = from  b = to c = increment

                tuple = r1.Fetch_data_snf(2);
                float a2 = float.Parse(tuple.Item1), b2 = float.Parse(tuple.Item2), c2 = float.Parse(tuple.Item3);// 3 different entries for 3 different values from database

                tuple = r1.Fetch_data_snf(3);
                float a3 = float.Parse(tuple.Item1), b3 = float.Parse(tuple.Item2), c3 = float.Parse(tuple.Item3);
                float i = rate;

                float j;

                if (snf < a1 || snf > b3)
                {
                    return 0;
                }

                if (snf > b1)
                {
                    i = i + ((b1 - a1) * c1 * 10);
                }
                else
                {
                    i = i + ((snf - a1) * c1 * 10);
                    return i;
                }


                if (snf > b2)
                {
                    i = i + ((b2 - a2) * c2 * 10);
                }
                else
                {
                    i = i + ((snf - a2) * c2 * 10);
                    return i;
                }

                if (snf > b3)
                {
                    i = i + ((b3 - a3) * c3 * 10);
                }
                else
                {
                    i = i + ((snf - a3) * c3 * 10);
                    return i;
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            
        }

        float getratefat2(float i, float fat)
        {
            try
            {
                rate_class r1 = new rate_class();
                var tuple = r1.Fetch_data_fat2(1);
                float a1 = float.Parse(tuple.Item1), b1 = float.Parse(tuple.Item2), c1 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_fat2(2);
                float a2 = float.Parse(tuple.Item1), b2 = float.Parse(tuple.Item2), c2 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_fat2(3);
                float a3 = float.Parse(tuple.Item1), b3 = float.Parse(tuple.Item2), c3 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_fat2(4);
                float a4 = float.Parse(tuple.Item1), b4 = float.Parse(tuple.Item2), c4 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_fat2(5);
                float a5 = float.Parse(tuple.Item1), b5 = float.Parse(tuple.Item2), c5 = float.Parse(tuple.Item3);
                float j;

                if (fat < a1 || fat > b5)
                {
                    return 0;
                }

                if (fat > b1)
                {
                    i = i + ((b1 - a1) * c1 * 10);
                }
                else
                {
                    i = i + ((fat - a1) * c1 * 10);
                    return i;
                }


                if (fat > b2)
                {
                    i = i + ((b2 - a2) * c2 * 10);
                }
                else
                {
                    i = i + ((fat - a2) * c2 * 10);
                    return i;
                }

                if (fat > b3)
                {
                    i = i + ((b3 - a3) * c3 * 10);
                }
                else
                {
                    i = i + ((fat - a3) * c3 * 10);
                    return i;
                }

                if (fat > b4)
                {
                    i = i + ((b4 - a4) * c4 * 10);
                }
                else
                {
                    i = i + ((fat - a4) * c4 * 10);
                    return i;
                }

                if (fat > b5)
                {
                    i = i + ((b5 - a5) * c5 * 10);
                }
                else
                {
                    i = i + ((fat - a5) * c5 * 10);
                    return i;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            
        }


        float getrate2(float rate, float snf)
        {
            try
            {
                rate_class r1 = new rate_class();
                var tuple = r1.Fetch_data_snf2(1);
                float a1 = float.Parse(tuple.Item1), b1 = float.Parse(tuple.Item2), c1 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_snf2(2);
                float a2 = float.Parse(tuple.Item1), b2 = float.Parse(tuple.Item2), c2 = float.Parse(tuple.Item3);

                tuple = r1.Fetch_data_snf2(3);
                float a3 = float.Parse(tuple.Item1), b3 = float.Parse(tuple.Item2), c3 = float.Parse(tuple.Item3);
                float i = rate;

                float j;

                if (snf < a1 || snf > b3)
                {
                    return 0;
                }

                if (snf > b1)
                {
                    i = i + ((b1 - a1) * c1 * 10);
                }
                else
                {
                    i = i + ((snf - a1) * c1 * 10);
                    return i;
                }


                if (snf > b2)
                {
                    i = i + ((b2 - a2) * c2 * 10);
                }
                else
                {
                    i = i + ((snf - a2) * c2 * 10);
                    return i;
                }

                if (snf > b3)
                {
                    i = i + ((b3 - a3) * c3 * 10);
                }
                else
                {
                    i = i + ((snf - a3) * c3 * 10);
                    return i;
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            password2 p2 = new password2();
            p2.ShowDialog();
        }
    }
}
