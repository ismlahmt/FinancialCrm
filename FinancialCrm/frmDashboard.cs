using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            var TotalBalance = db.Banks.Sum(x => x.Balance) + " ₺";
            lblTotalBalance.Text = TotalBalance.ToString();
            var Lastbankprocessamount = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=> y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = Lastbankprocessamount.ToString()+ " ₺";

            //Chart 1 
            var bankData = db.Banks.Select(x => new 
            {
                x.BankTitle,
                x.Balance,

            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.Balance);
            }

            //Chart 2
            var billData = db.Bills.Select(x=> new
            {
                x.BillTitle,
                x.BillAmount,
            }).ToList();
            chart2.Series.Clear();
            var series2 =chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Renko;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle,item.BillAmount);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count ++;
            if (count % 4 == 1)
            {
                var elektrikfaturasi = db.Bills.Where(x=> x.BillTitle == "Elektrik Faturası").Select(y=>y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrikfaturasi.ToString() + " ₺";
            }
            if (count % 4== 2)
            {
                var dogalgazfaturasi = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = dogalgazfaturasi.ToString() + " ₺";
            }
            if (count % 4 == 3)
            {
                var sufaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = sufaturasi.ToString() + " ₺";
            }
            if (count % 4 == 0)
            {
                var internetfaturasi = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = internetfaturasi.ToString() + " ₺";
            }
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillFrom_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
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
            frmDashboard frm = new frmDashboard();
            frm.Close();
            this.Close();
        }
    }
}
