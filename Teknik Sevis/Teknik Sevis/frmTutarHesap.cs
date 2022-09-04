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
    public partial class frmTutarHesap : Form
    {
        public frmTutarHesap()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListeleFiyat()
        {
            #region GridView Listeleme
            //gridFiyatlar.DataSource = db.Bilet.ToList(); tümünü listelemek için.
            //gridFiyatlar dan istediğimiz bilgileri listeletme
            gridFiyatlar.DataSource = db.İslemTur.Select(x =>
                new
                {
                    x.ad,
                    x.ucret
                }).ToList();
            #endregion
        }
        public void Fiyatlar()
        {
            #region GridView Listelesinden checkboxlara ücretleri tanımlama.
            var format = db.İslemTur.Where(x => x.ad == lblFormat.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblFfiyat.Text = Convert.ToString((decimal)format.ucret);

            var ekran = db.İslemTur.Where(x => x.ad == lblEkran.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblEfiyat.Text = Convert.ToString((decimal)ekran.ucret);

            var batarya = db.İslemTur.Where(x => x.ad == lblBatarya.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblBfiyat.Text = Convert.ToString((decimal)batarya.ucret);

            var temizlik = db.İslemTur.Where(x => x.ad == lblTemizlik.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblTfiyat.Text = Convert.ToString((decimal)temizlik.ucret);

            var anakart = db.İslemTur.Where(x => x.ad == lblAnakart.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblAfiyat.Text = Convert.ToString((decimal)anakart.ucret);

            var ses = db.İslemTur.Where(x => x.ad == lblSes.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblSfiyat.Text = Convert.ToString((decimal)ses.ucret);

            var fan = db.İslemTur.Where(x => x.ad == lblFan.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblFanFiyat.Text = Convert.ToString((decimal)fan.ucret);

            var ram = db.İslemTur.Where(x => x.ad == lblRam.Text).Select(x => new { x.ucret }).SingleOrDefault();
            lblRfiyat.Text = Convert.ToString((decimal)ram.ucret);
            #endregion
        }


        private void btnOnayla_Click(object sender, EventArgs e)
        {
            frmArizaKayit frm = new frmArizaKayit();
            this.Hide();
            frm.txtTutar.Text =Convert.ToDecimal( lblTutar.Text).ToString();
            frm.Show();
        }

    private void frmTutarHesap_Load(object sender, EventArgs e)
        {
            ListeleFiyat();
            Fiyatlar();
        }

        private void chcFormat_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox format basılma durumu ayarı.
            if (chcFormat.Checked==true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblFfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            if (chcFormat.Checked == false)
            {
                if (Convert.ToDecimal(lblEfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblFfiyat.Text)).ToString();
                }
                if (Convert.ToDecimal(lblEfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblFfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcEkran_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Ekran basılma durumu ayarı.
            if (chcEkran.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblEfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            if (chcEkran.Checked == false)
            {
                if (Convert.ToDecimal(lblEfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text)-Convert.ToDecimal(lblEfiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblEfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblEfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcBatarya_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Batarya basılma durumu ayarı.
            if (chcBatarya.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblBfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            else if (chcBatarya.Checked == false)
            {
                if (Convert.ToDecimal(lblBfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblBfiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblBfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblBfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcTemizlik_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Temizlik basılma durumu ayarı.
            if (chcTemizlik.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblTfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            else if (chcTemizlik.Checked == false)
            {
                if (Convert.ToDecimal(lblTfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblTfiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblTfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcAnakart_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Ankart basılma durumu ayarı.
            if (chcAnakart.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblAfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            else if (chcAnakart.Checked == false)
            {
                if (Convert.ToDecimal(lblAfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblAfiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblAfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblAfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcSes_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Ses Sistemi basılma durumu ayarı.
            if (chcSes.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblSfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            else if (chcSes.Checked == false)
            {
                if (Convert.ToDecimal(lblSfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblSfiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblSfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblSfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcFan_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Fan basılma durumu ayarı.
            if (chcFan.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblFanFiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            else if (chcFan.Checked == false)
            {
                if (Convert.ToDecimal(lblFanFiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblFanFiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblFanFiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblFanFiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void chcRam_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox Ram basılma durumu ayarı.
            if (chcRam.Checked == true)
            {
                lblTutar.Text = (Convert.ToDecimal(lblRfiyat.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
            }
            else if (chcRam.Checked == false)
            {
                if (Convert.ToDecimal(lblRfiyat.Text) < Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblTutar.Text) - Convert.ToDecimal(lblRfiyat.Text)).ToString();
                }
                else if (Convert.ToDecimal(lblRfiyat.Text) > Convert.ToDecimal(lblTutar.Text))
                {
                    lblTutar.Text = (Convert.ToDecimal(lblRfiyat.Text) - Convert.ToDecimal(lblTutar.Text)).ToString();
                }
            }
            #endregion
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            frmArizaKayit frm = new frmArizaKayit();
            this.Hide();
            frm.txtTutar.Text = Convert.ToDecimal(lblTutar.Text).ToString();
            frm.Show();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            lblTutar.Text= (Convert.ToDecimal(txtEkstra.Text) + Convert.ToDecimal(lblTutar.Text)).ToString();
        }

    }
    
}
