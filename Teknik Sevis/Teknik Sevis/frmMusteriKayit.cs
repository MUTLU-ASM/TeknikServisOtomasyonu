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
    public partial class frmMusteriKayit : Form
    {
        public frmMusteriKayit()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListeleMusteri()
        {
            #region GridView Listeleme
            //gridMusteriListe.DataSource = db.Bilet.ToList(); tümünü listelemek için.
            //gridMusteriListe 'sine istediğimiz bilgileri listeletme
            gridMusteriListe.DataSource = db.Musteri.Select(x =>
                new
                {
                   x.ad,
                    x.soyad,
                     x.telefon,
                      x.adres
                }).ToList();
            #endregion
        }

        public void Temizle()
        {
            #region textboxların iclerindeki verileri silme.
            txtAd.Text = "";
            txtSoyad.Text = "";
            msktxtTelefon.Text = "";
            rchtxtAdres.Text = "";
            txtAd.Focus();
            #endregion
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmAnasayfa frm = new frmAnasayfa();
            this.Hide();
            frm.Show();
            
        }

        private void frmMusteriKayit_Load(object sender, EventArgs e)
        {
            ListeleMusteri();
        }

        private void gridMusteriListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Grid'de seçilen satırı textbox lara geçirme.
            txtAd.Text = gridMusteriListe.SelectedRows[0].Cells[0].Value.ToString();
            txtSoyad.Text = gridMusteriListe.SelectedRows[0].Cells[1].Value.ToString();
            msktxtTelefon.Text = gridMusteriListe.SelectedRows[0].Cells[2].Value.ToString();
            rchtxtAdres.Text = gridMusteriListe.SelectedRows[0].Cells[3].Value.ToString();
            #endregion
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            #region kaydetme islemi
            if (txtAd.Text=="" && txtSoyad.Text=="" && msktxtTelefon.Text=="" && rchtxtAdres.Text=="")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Musteri m = new Musteri();
                m.ad = txtAd.Text;
                m.soyad = txtSoyad.Text;
                m.telefon = msktxtTelefon.Text;
                m.adres = rchtxtAdres.Text;
                db.Musteri.Add(m);
                db.SaveChanges();

                MessageBox.Show(m.ad +" " +m.soyad+ " adlı müşteri başarılı bir şekilde kaydolmuştur.", "Müşteri Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListeleMusteri();
                Temizle();
            }
            #endregion

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            #region silme islemi
            Musteri ad = db.Musteri.Where(x => x.ad == txtAd.Text).SingleOrDefault();
            if (ad != null) //bulunduysa sil
            {
                DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Müşteri Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes) //Silme işlemine evet denmesi durumunda gerçekleşecek.
                {
                    db.Musteri.Remove(ad);
                    db.SaveChanges();
                    ListeleMusteri();
                    MessageBox.Show("Başarılı silme işlemi .", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//Silme işlemine hayır denmesi durumunda gerçekleşecek.
                {
                    MessageBox.Show("İşlem İptal edildi.", "Müşteri kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtAd.Text == "" && txtSoyad.Text == "" && msktxtTelefon.Text == "" && rchtxtAdres.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
            Musteri m = db.Musteri.Where(x => x.ad == txtAd.Text).SingleOrDefault();
            m.ad = txtAd.Text;
            m.soyad = txtSoyad.Text;
            m.telefon = msktxtTelefon.Text;
            m.adres = rchtxtAdres.Text;
            db.SaveChanges();
            ListeleMusteri();
            Temizle();
            MessageBox.Show("Başarıyla Düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            #region Kelimeye göre listede aratma
            string aranan = txtAra.Text.Trim().ToUpper();
            for (int i = 0; i <= gridMusteriListe.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in gridMusteriListe.Rows)
                {
                    foreach (DataGridViewCell cell in gridMusteriListe.Rows[i].Cells)
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
