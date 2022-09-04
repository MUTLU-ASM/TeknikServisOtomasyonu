using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknik_Sevis
{
    public partial class frmHesapMakine : Form
    {
        public frmHesapMakine()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double sayi1, sayi2, sonuc;
            btnEkle.Enabled = true;
            if (txtSayi1.Text == "")
            {

                MessageBox.Show("Lütfen boş geçmeyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSayi2.Text == "")
            {

                MessageBox.Show("Lütfen boş geçmeyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbIslemler.Text == "")
            {

                MessageBox.Show("Lütfen boş geçmeyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sayi1 = Convert.ToDouble(txtSayi1.Text);
            sayi2 = Convert.ToDouble(txtSayi2.Text);
            if (cmbIslemler.SelectedIndex == 0)
            {
                sonuc = sayi1 + sayi2;
                txtSonuc.Text = sonuc.ToString();
            }
            else if (cmbIslemler.SelectedIndex == 1)
            {
                sonuc = sayi1 - sayi2;
                txtSonuc.Text = sonuc.ToString();
            }
            else if (cmbIslemler.SelectedIndex == 2)
            {
                sonuc = sayi1 * sayi2;
                txtSonuc.Text = sonuc.ToString();
            }
            else if (cmbIslemler.SelectedIndex == 3)
            {
                sonuc = sayi1 / sayi2;
                txtSonuc.Text = sonuc.ToString();
                return;

            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtSayi1.Text == "" || txtSayi2.Text == "" || txtSonuc.Text == "")
            {
                MessageBox.Show("Lütfen boş geçmeyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtSayi1.Text = txtSonuc.Text;
            txtSayi2.Text = "";
            txtSonuc.Text = "";
            btnEkle.Enabled = false;
            txtSayi2.Focus();
        }

        private void frmHesapMakine_Load(object sender, EventArgs e)
        {
            btnEkle.Enabled = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtSayi1.Text ="";
            txtSayi2.Text = "";
            txtSonuc.Text = "";
            btnEkle.Enabled = false;
            txtSayi1.Focus();
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmAnasayfa frm = new frmAnasayfa();
            this.Hide();
            frm.Show();
        }
    }
}
