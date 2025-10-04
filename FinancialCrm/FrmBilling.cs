using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string Title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle= Title;
            bills.BillAmount= amount;
            bills.BillPeriod= period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarıyla Eklendi." ,"Ödeme&Faturalar" , MessageBoxButtons.OK, MessageBoxIcon.Information);

            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            var billid = int.Parse(txtBillId.Text);
            
            var removeValue = db.Bills.Find(billid);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarıyla Silindi.", "Ödeme&Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;


        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            var billid = int.Parse(txtBillId.Text);
            var updateValue = db.Bills.Find(billid);


            string title = txtBillTitle.Text;
            string period = txtBillPeriod.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);

            updateValue.BillTitle = title;
            updateValue.BillAmount = amount;
            updateValue.BillPeriod = period;

            db.SaveChanges();
            MessageBox.Show("Ödeme Başarıyla Güncellendi.", "Ödeme&Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;

        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }



        private void btnFrmDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            this.Close();
        }

        private void btnFrmExit_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Close();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Close();
        }
    }
}
