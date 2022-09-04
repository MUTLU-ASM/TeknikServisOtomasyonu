using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teknik_Sevis.Models;

namespace Teknik_Sevis
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta, sifre;
            eposta = txtEposta.Text;
            sifre = txtSifre.Text;

            if (eposta == "" || sifre == "")
            {
                MessageBox.Show("Alanlar boş geçilemez.");
                return;
            }

            Kullanici personel = db.Kullanici.Where(x => x.eposta == eposta && x.sifre == sifre && x.yetkiID == 2).SingleOrDefault();
            Kullanici yonetici = db.Kullanici.Where(x => x.eposta == eposta && x.sifre == sifre && x.yetkiID==1).SingleOrDefault();
            if (personel != null)
            {

                Program.kullanici = personel;
                frmAnasayfa frm = new frmAnasayfa();
                frm.lblAd.Text = db.Kullanici.Where(x => x.eposta == eposta).Select(x => x.ad).SingleOrDefault();
                frm.lblSoyad.Text= db.Kullanici.Where(x => x.eposta == eposta).Select(x => x.soyad).SingleOrDefault();
                frm.Show();
                this.Hide();
            }
            else if (yonetici != null)
            {
                Program.kullanici = yonetici;
                new frmYoneticiSayfasi().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Eposta veya şifre hatalı");
                txtSifre.Text = "";
                txtSifre.Focus();
            }
        }
    }
}
