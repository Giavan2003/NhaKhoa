using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace NhaKhoa
{
    public partial class PaymentForm : Form
    {
        private int patientid;
        PLANSERVICES plan = new PLANSERVICES();
        MEDICINES medicines    = new MEDICINES();
        public PaymentForm(int id)
        {
            InitializeComponent();
            this.patientid = id;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            label1.Text = patientid.ToString();
            load();
        }
        private void load()
        {
            DataTable dt = medicines.Showpay(patientid);
            guna2DataGridView1.DataSource = dt;
            DataTable dt2 = plan.Showpay(patientid);
            guna2DataGridView2.DataSource = dt2;
            double totalPrice = CalculateTotalPrice(dt);
            double totalDiscount = CalculateTotalDiscount(dt);
            double totalPayment = CalculateTotalPayment(dt);
            lb_tienthuoc.Text = ("Giá tiền thuốc: " + totalPrice);
            lb_tienthuocgiam.Text = ("Giảm giá: " + totalDiscount);
            lb_tongtienthuoc.Text = ("Tổng tiền thuốc: " + totalPayment);
            double totalPrice2 = CalculateTotalPrice(dt2);
            double totalDiscount2 = CalculateTotalDiscount(dt2);
            double totalPayment2 = CalculateTotalPayment(dt2);
            lb_tiendichvu.Text = ("Giá tiền dịch vụ: " + totalPrice2);
            lb_tiendichvugiam.Text = ("Giảm giá: " + totalDiscount2);
            lb_tongtiendichvu.Text = ("Tổng tiền dịch vụ: " + totalPayment2);
            double total = totalPayment2 + totalPayment;
            lb_tongtien.Text = ("Thanh toán: " + total);
        }
        public double CalculateTotalPrice(DataTable dataTable)
        {
            double totalPrice = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy giá và số lượng của mỗi dòng và nhân lại với nhau, sau đó cộng vào tổng giá
                double price = Convert.ToDouble(row["Price"]);
                double quantity = Convert.ToDouble(row["Quantity"]);
                totalPrice += price * quantity;
            }

            return totalPrice;
        }

        public double CalculateTotalDiscount(DataTable dataTable)
        {
            double totalDiscount = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy giảm giá của mỗi dòng và cộng vào tổng giảm giá
                totalDiscount += Convert.ToDouble(row["Discount"]);
            }

            return totalDiscount;
        }
        public double CalculateTotalPayment(DataTable dataTable)
        {
            double totalPayment = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy thanh toán của mỗi dòng và cộng vào tổng thanh toán
                totalPayment += Convert.ToDouble(row["Payment"]);
            }

            return totalPayment;
        }

        private void bt_thanhtoan_Click(object sender, EventArgs e)
        {
            DataTable dt = medicines.Showpay(patientid);
            DataTable dt2 = plan.Showpay(patientid);
            double total = CalculateTotalPayment(dt) + CalculateTotalPayment(dt2);

            try
            {
                if ((MessageBox.Show("Do you want to pay the amount: " + total, "Pay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    plan.UpdatePaid(patientid);
                    medicines.UpdatePaid(patientid);
                    MessageBox.Show("Payment successd", "Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    MessageBox.Show("Payment failed", "Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Payment failed", "Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
