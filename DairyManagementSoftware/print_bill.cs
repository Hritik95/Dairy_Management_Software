using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyManagementSoftware
{
    public partial class print_bill : Form
    {

        public string col_total, sales_total, grand_total;
        public int mem_id;

        PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        PrintDocument pntdoc = new PrintDocument();

        private void print_bill_Load(object sender, EventArgs e)
        {
            id_bill.Text = mem_id.ToString();
            col_tot.Text = col_total;
            sales_tot.Text = sales_total;
            grand_tot.Text = grand_total;

            try
            {
                int id = mem_id;
                member_class m5 = new member_class();
                var tuple = m5.Fetch_data(id);
                if (tuple.Item3 == "-1")
                {
                    MessageBox.Show("Record not found");
                    name.Text = "";
                    address.Text = "";
                    phone.Text = "";
                }
                else
                {
                    name.Text = tuple.Item1;
                    address.Text = tuple.Item2;
                    phone.Text = tuple.Item3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public print_bill()
        {
            InitializeComponent();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }

        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            prntprvw.Document = pntdoc;
            pntdoc.PrintPage += new PrintPageEventHandler(pntdoc_printpage);
            prntprvw.ShowDialog();
        }

        public void pntdoc_printpage(object  sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memorying, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        Bitmap memorying;
        public void getprintarea(Panel pnl)
        {
            memorying = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memorying,new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
    }
}
