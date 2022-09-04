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
    public partial class frmArizaKayit : Form
    {
        public frmArizaKayit()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListeleKayit()
        {
            #region GridView Listeleme
            //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
            //gridKayit dan istediğimiz bilgileri listeletme
            gridKayit.DataSource = db.Kayit.Select(x =>
                new
                {
                   Musteri=x.Musteri.telefon,
                    Kullanici=x.Kullanici.ad,
                     Tur=x.Tur.ad,
                       Marka=x.Marka.ad,
                        x.model,
                         x.sorun,
                          x.alisTarihi,
                           x.teslimTarihi,
                            x.tutar,
                             x.aciklama,
                              x.durum
                }).ToList();
            #endregion
        }
        public void Temizle()
        {
            #region textboxların iclerindeki verileri silme.
            cmbMusteri.Text = "";
            cmbPersonel.Text = "";
            cmbTur.Text = "";
            cmbMarka.Text = "";
            txtModel.Text = "";
            msktxtTeslimTarihi.Text = "";
            msktxtAlisTarih.Text = "";
            rchtxtSorun.Text = "";
            rchtxtAciklama.Text = "";
            txtTutar.Text = "";
            cmbDurum.Text = "";
            cmbMusteri.Focus();
            #endregion
        }

        private void frmArizaKayit_Load(object sender, EventArgs e)
        {
            ListeleKayit();

            #region musteri adlarini combobox da listeletme
            var listeMusteri = db.Musteri.Select(x => new
            {
                x.musteriID,
                telefon=x.telefon
            }
            ).ToList();
            cmbMusteri.DataSource = listeMusteri;
            cmbMusteri.DisplayMember = "telefon";
            cmbMusteri.ValueMember = "musteriID";
            #endregion

            #region Personel adlarini combobox da listeletme
            var listePersonel = db.Kullanici.Where(x=> x.yetkiID==2).Select(x => new
            {
                x.kullaniciID,
                eposta = x.eposta
            }
            ).ToList();
            cmbPersonel.DataSource = listePersonel;
            cmbPersonel.DisplayMember = "eposta";
            cmbPersonel.ValueMember = "kullaniciID";
            #endregion

            #region Tur adlarini combobox da listeletme
            var listeTur = db.Tur.Select(x => new
            {
                x.turID,
                ad = x.ad
            }
            ).ToList();
            cmbTur.DataSource = listeTur;
            cmbTur.DisplayMember = "ad";
            cmbTur.ValueMember = "turID";
            #endregion

            #region marka adlarini combobox da listeletme
            var listeMarka = db.Marka.Select(x => new
            {
                x.markaID,
                ad = x.ad
            }
            ).ToList();
            cmbMarka.DataSource = listeMarka;
            cmbMarka.DisplayMember = "ad";
            cmbMarka.ValueMember = "markaID";
            #endregion
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            #region Kelimeye göre listede aratma
            string aranan = txtAra.Text.Trim().ToUpper();
            for (int i = 0; i <= gridKayit.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in gridKayit.Rows)
                {
                    foreach (DataGridViewCell cell in gridKayit.Rows[i].Cells)
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

        private void gridKayit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Grid'de seçilen satırı textbox lara geçirme.
            cmbMusteri.Text = gridKayit.SelectedRows[0].Cells[0].Value.ToString();
            cmbPersonel.Text = gridKayit.SelectedRows[0].Cells[1].Value.ToString();
            cmbTur.Text = gridKayit.SelectedRows[0].Cells[2].Value.ToString();
            cmbMarka.Text = gridKayit.SelectedRows[0].Cells[3].Value.ToString();
            txtModel.Text = gridKayit.SelectedRows[0].Cells[4].Value.ToString();
            rchtxtSorun.Text = gridKayit.SelectedRows[0].Cells[5].Value.ToString();
            msktxtAlisTarih.Text = gridKayit.SelectedRows[0].Cells[6].Value.ToString();
            msktxtTeslimTarihi.Text = gridKayit.SelectedRows[0].Cells[7].Value.ToString();
            txtTutar.Text = gridKayit.SelectedRows[0].Cells[8].Value.ToString();
            rchtxtAciklama.Text = gridKayit.SelectedRows[0].Cells[9].Value.ToString();
            cmbDurum.Text = gridKayit.SelectedRows[0].Cells[10].Value.ToString();
            #endregion
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            #region kaydetme islemi
            if (cmbMusteri.Text == "" && cmbPersonel.Text == "" && cmbTur.Text == "" && cmbMarka.Text == "" && txtModel.Text == "" && msktxtAlisTarih.Text == ""
                && msktxtTeslimTarihi.Text == "" && rchtxtSorun.Text == "" && rchtxtAciklama.Text == "" && cmbDurum.Text == "" && txtTutar.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kayit k = new Kayit();
                var MusteriID = db.Musteri.Where(x => x.telefon == cmbMusteri.Text).Select(x=>x.musteriID).SingleOrDefault();
                k.musteriID = MusteriID;
                var PersonelID = db.Kullanici.Where(x => x.eposta == cmbPersonel.Text).Select(x => x.kullaniciID).SingleOrDefault();
                k.kullaniciID = PersonelID;
                var TurID = db.Tur.Where(x => x.ad == cmbTur.Text).Select(x => x.turID).SingleOrDefault();
                k.turID = TurID;
                var MarkaID = db.Marka.Where(x => x.ad == cmbMarka.Text).Select(x => x.markaID).SingleOrDefault();
                k.markaID = MarkaID;
                k.musteriID = MusteriID;
                k.model = txtModel.Text;
                k.alisTarihi = Convert.ToDateTime(msktxtAlisTarih.Text);
                k.teslimTarihi = Convert.ToDateTime( msktxtTeslimTarihi.Text);
                k.tutar =Convert.ToDecimal( txtTutar.Text);
                k.sorun = rchtxtSorun.Text;
                k.aciklama = rchtxtAciklama.Text;
                k.durum =Convert.ToBoolean(cmbDurum.Text);
                db.Kayit.Add(k);
                db.SaveChanges();

                MessageBox.Show(cmbMusteri.Text+ " telefonlu müşterinin arıza kaydı başarılı bir şekilde kaydolmuştur.", "Arıza Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListeleKayit();
                Temizle();
            }
            #endregion
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            #region silme islemi
            Kayit kayit = db.Kayit.Where(x => x.Musteri.telefon == cmbMusteri.Text).SingleOrDefault();
            if (kayit != null) //bulunduysa sil
            {
                DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes) //Silme işlemine evet denmesi durumunda gerçekleşecek.
                {
                    db.Kayit.Remove(kayit);
                    db.SaveChanges();
                    ListeleKayit();
                    MessageBox.Show("Başarılı silme işlemi .", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//Silme işlemine hayır denmesi durumunda gerçekleşecek.
                {
                    MessageBox.Show("İşlem İptal edildi.", "Arıza kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cmbMusteri.Text == "" && cmbPersonel.Text == "" && cmbTur.Text == "" && cmbMarka.Text == "" && txtModel.Text == "" && msktxtAlisTarih.Text == ""
                && msktxtTeslimTarihi.Text == "" && rchtxtSorun.Text == "" && rchtxtAciklama.Text == "" && cmbDurum.Text == "" && txtTutar.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kayit k = db.Kayit.Where(x => x.Musteri.telefon == cmbMusteri.Text).SingleOrDefault();
                var MusteriID = db.Musteri.Where(x => x.telefon == cmbMusteri.Text).Select(x => x.musteriID).SingleOrDefault();
                k.musteriID = MusteriID;
                var PersonelID = db.Kullanici.Where(x => x.eposta == cmbPersonel.Text).Select(x => x.kullaniciID).SingleOrDefault();
                k.kullaniciID = PersonelID;
                var TurID = db.Tur.Where(x => x.ad == cmbTur.Text).Select(x => x.turID).SingleOrDefault();
                k.turID = TurID;
                var MarkaID = db.Marka.Where(x => x.ad == cmbMarka.Text).Select(x => x.markaID).SingleOrDefault();
                k.markaID = MarkaID;
                k.musteriID = MusteriID;
                k.model = txtModel.Text;
                k.alisTarihi = Convert.ToDateTime(msktxtAlisTarih.Text);
                k.teslimTarihi = Convert.ToDateTime(msktxtTeslimTarihi.Text);
                k.tutar = Convert.ToDecimal(txtTutar.Text);
                k.sorun = rchtxtSorun.Text;
                k.aciklama = rchtxtAciklama.Text;
                k.durum = Convert.ToBoolean(cmbDurum.Text);
                db.SaveChanges();
                ListeleKayit();
                Temizle();
                MessageBox.Show("Başarıyla Düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmAnasayfa frm = new frmAnasayfa();
            this.Hide();
            frm.Show();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            frmTutarHesap frm = new frmTutarHesap();
            this.Hide();
            frm.Show();
        }

    }
}
