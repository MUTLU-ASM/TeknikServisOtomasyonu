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
    public partial class frmPersonelIslemleri : Form
    {
        public frmPersonelIslemleri()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListelePersonel()
        {
            #region GridView Listeleme
            gridPersonel.DataSource = db.Kullanici.Where(x=>x.yetkiID==2).Select(x =>
                new
                {
                    Yetki=x.Yetki.ad,
                    x.ad,
                    x.soyad,
                    x.eposta,
                    x.sifre
                }).ToList();
            #endregion
        }

        public void Temizle()
        {
            #region textboxların iclerindeki verileri silme.
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtEposta.Text = "@gmail.com";
            txtSifre.Text = "";
            txtAd.Focus();
            #endregion
        }

        private void frmPersonelIslemleri_Load(object sender, EventArgs e)
        {
            ListelePersonel();  
        }

        private void gridPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Grid'de seçilen satırı textbox lara geçirme.
            txtAd.Text = gridPersonel.SelectedRows[0].Cells[1].Value.ToString();
            txtSoyad.Text = gridPersonel.SelectedRows[0].Cells[2].Value.ToString();
            txtEposta.Text = gridPersonel.SelectedRows[0].Cells[3].Value.ToString();
            txtSifre.Text = gridPersonel.SelectedRows[0].Cells[4].Value.ToString();
            #endregion
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            #region kaydetme islemi
            if (txtAd.Text == "" && txtSoyad.Text == "" && txtEposta.Text == "" && txtSifre.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kullanici p = new Kullanici();
                p.yetkiID = Convert.ToInt32(txtyetkiID.Text);
                p.ad = txtAd.Text;
                p.soyad = txtSoyad.Text;
                p.eposta = txtEposta.Text;
                p.sifre = txtSifre.Text;
                db.Kullanici.Add(p);
                db.SaveChanges();

                MessageBox.Show(p.ad + " " + p.soyad + " adlı personel başarılı bir şekilde kaydolmuştur.", "Personel Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListelePersonel();
                Temizle();
            }
            #endregion
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            #region silme islemi
            Kullanici ad = db.Kullanici.Where(x => x.ad == txtAd.Text).SingleOrDefault();
            if (ad != null) //bulunduysa sil
            {
                DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Personel Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes) //Silme işlemine evet denmesi durumunda gerçekleşecek.
                {
                    db.Kullanici.Remove(ad);
                    db.SaveChanges();
                    ListelePersonel();
                    MessageBox.Show("Başarılı silme işlemi .", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//Silme işlemine hayır denmesi durumunda gerçekleşecek.
                {
                    MessageBox.Show("İşlem İptal edildi.", "Personel kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Temizle();
            #endregion
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            #region Duzenleme islemi
            if (txtAd.Text == "" && txtSoyad.Text == "" && txtEposta.Text == "" && txtSifre.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kullanici p = db.Kullanici.Where(x => x.ad == txtAd.Text).SingleOrDefault();
                p.ad = txtAd.Text;
                p.soyad = txtSoyad.Text;
                p.eposta = txtEposta.Text;
                p.sifre = txtSifre.Text;
                db.SaveChanges();
                ListelePersonel();
                Temizle();
                MessageBox.Show("Başarıyla Düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmYoneticiSayfasi frm = new frmYoneticiSayfasi();
            this.Hide();
            frm.Show();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            #region Kelimeye göre listede aratma
            string aranan = txtAra.Text.Trim().ToUpper();
            for (int i = 0; i <= gridPersonel.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in gridPersonel.Rows)
                {
                    foreach (DataGridViewCell cell in gridPersonel.Rows[i].Cells)
                    {
                        cell.Style.BackColor = Color.White;
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion
        }

    }
}
