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
    public partial class frmMarkaTurIslem : Form
    {
        public frmMarkaTurIslem()
        {
            InitializeComponent();
        }
        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListeleTur()
        {
            #region GridView Listeleme
            gridTur.DataSource = db.Tur.Select(x =>
                new
                {
                    x.ad
                }).ToList();
            #endregion
        }
        public void ListeleMarka()
        {
            #region GridView Listeleme
            gridMarka.DataSource = db.Marka.Select(x =>
                new
                {
                    x.ad
                }).ToList();
            #endregion
        }
        public void Temizle()
        {
            #region textboxların iclerindeki verileri silme.
            txtTurAd.Text = "";
            txtMarkaAd.Text = "";
            txtTurAd.Focus();
            #endregion
        }

        private void frmMarkaTurIslem_Load(object sender, EventArgs e)
        {
            ListeleTur();
            ListeleMarka();
        }

        #region Tur --> Kaydet - Sil - Duzenle -- Grid -- Arama Ayarları
        private void btnTkaydet_Click(object sender, EventArgs e)
        {
            #region kaydetme islemi
            if (txtTurAd.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yeri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Tur t = new Tur();
                t.ad = txtTurAd.Text;
                db.Tur.Add(t);
                db.SaveChanges();

                MessageBox.Show(t.ad+ " İsimli Tür başarılı bir şekilde kaydolmuştur.", "Tür Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListeleTur();
                Temizle();
            }
            #endregion
        }

        private void btnTsil_Click(object sender, EventArgs e)
        {
            #region silme islemi
            Tur ad = db.Tur.Where(x => x.ad == txtTurAd.Text).SingleOrDefault();
            if (ad != null) //bulunduysa sil
            {
                DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Tür Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes) //Silme işlemine evet denmesi durumunda gerçekleşecek.
                {
                    db.Tur.Remove(ad);
                    db.SaveChanges();
                    ListeleTur();
                    MessageBox.Show("Başarılı silme işlemi .", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//Silme işlemine hayır denmesi durumunda gerçekleşecek.
                {
                    MessageBox.Show("İşlem İptal edildi.", "Tür kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Temizle();
            #endregion
        }

        private void btnTduzenle_Click(object sender, EventArgs e)
        {
            #region Duzenleme islemi
            if (txtTurAd.Text == "" )
            {
                MessageBox.Show("Lütfen Boş Yeri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Tur t = db.Tur.Where(x => x.ad == txtTurAd.Text).SingleOrDefault();
                t.ad = txtTurAd.Text;
                db.SaveChanges();
                ListeleTur();
                Temizle();
                MessageBox.Show("Başarıyla Düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void gridTur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Grid'de seçilen satırı textbox lara geçirme.
            txtTurAd.Text = gridTur.SelectedRows[0].Cells[0].Value.ToString();
            #endregion
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            #region Kelimeye göre listede aratma
            string aranan = txtAra.Text.Trim().ToUpper();
            for (int i = 0; i <= gridTur.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in gridTur.Rows)
                {
                    foreach (DataGridViewCell cell in gridTur.Rows[i].Cells)
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
        #endregion

        #region Marka --> Kaydet - Sil - Duzenle -- Grid -- Arama Ayarları
        private void btnMkaydet_Click(object sender, EventArgs e)
        {
            #region kaydetme islemi
            if (txtMarkaAd.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yeri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Marka m = new Marka();
                m.ad = txtMarkaAd.Text;
                db.Marka.Add(m);
                db.SaveChanges();

                MessageBox.Show(m.ad + " İsimli Marka başarılı bir şekilde kaydolmuştur.", "Marka Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListeleMarka();
                Temizle();
            }
            #endregion
        }

        private void btnMsil_Click(object sender, EventArgs e)
        {
            #region silme islemi
            Marka ad = db.Marka.Where(x => x.ad == txtMarkaAd.Text).SingleOrDefault();
            if (ad != null) //bulunduysa sil
            {
                DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Marka Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes) //Silme işlemine evet denmesi durumunda gerçekleşecek.
                {
                    db.Marka.Remove(ad);
                    db.SaveChanges();
                    ListeleMarka();
                    MessageBox.Show("Başarılı silme işlemi .", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//Silme işlemine hayır denmesi durumunda gerçekleşecek.
                {
                    MessageBox.Show("İşlem İptal edildi.", "Marka kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Temizle();
            #endregion
        }

        private void btnMduzenle_Click(object sender, EventArgs e)
        {
            #region Duzenleme islemi
            if (txtMarkaAd.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yeri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Marka m = db.Marka.Where(x => x.ad == txtMarkaAd.Text).SingleOrDefault();
                m.ad = txtMarkaAd.Text;
                db.SaveChanges();
                ListeleMarka();
                Temizle();
                MessageBox.Show("Başarıyla Düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void gridMarka_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Grid'de seçilen satırı textbox lara geçirme.
            txtMarkaAd.Text = gridTur.SelectedRows[0].Cells[0].Value.ToString();
            #endregion
        }



        private void txtMara_TextChanged(object sender, EventArgs e)
        {
            #region Kelimeye göre listede aratma
            string aranan = txtAra.Text.Trim().ToUpper();
            for (int i = 0; i <= gridMarka.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in gridMarka.Rows)
                {
                    foreach (DataGridViewCell cell in gridMarka.Rows[i].Cells)
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
        #endregion

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmYoneticiSayfasi frm = new frmYoneticiSayfasi();
            this.Hide();
            frm.Show();
        }
    }
}
