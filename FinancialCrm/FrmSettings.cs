using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            frmPasswordChange frm = new frmPasswordChange();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnFrmDashboard_Click(object sender, EventArgs e)
        {
            
            
                frmDashboard frm = new frmDashboard();
                frm.Show();
                this.Hide();
            
            
        }

        private void btnFrmExit_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Close();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            
            
                FrmSettings frm = new FrmSettings();
                frm.Show();
                this.Hide();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                MessageBox.Show("Giriş Başarılı!", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                AuthManager.IsAuthenticated = true;
                btnBanksForm.Enabled = true;
                btnFrmDashboard.Enabled = true;
                btnPasswordChange.Enabled = true;
                btnUsernameChange.Enabled = true;
                btnFrmBills.Enabled = true;
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            if (AuthManager.IsAuthenticated)
            {
                btnBanksForm.Enabled = true;
                btnFrmDashboard.Enabled = true;
                btnPasswordChange.Enabled = true;
                btnFrmBills.Enabled = true;
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;
                btnUsernameChange.Enabled = true;
                btnLogin.Enabled = false;
            }
            else
            {
                btnBanksForm.Enabled = false;
                btnFrmDashboard.Enabled = false;
                btnPasswordChange.Enabled = false;
                btnFrmBills.Enabled = false;
                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                btnLogin.Enabled = true;
                btnUsernameChange.Enabled = false;
            }
                
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFrmBills_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnUsernameChange_Click(object sender, EventArgs e)
        {
            frmUsernameChange frm = new frmUsernameChange();
            frm.Show();
            this.Hide();
        }
    }
}
