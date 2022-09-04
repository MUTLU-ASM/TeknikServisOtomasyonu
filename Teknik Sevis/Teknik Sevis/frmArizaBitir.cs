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
    public partial class frmArizaBitir : Form
    {
        public frmArizaBitir()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListeleKayit()
        {
            #region GridView arızalı olanları Listeleme
            //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
            //gridKayit dan istediğimiz bilgileri listeletme
            gridArizaListe.DataSource = db.Kayit.Where(x => x.durum == false).Select(x =>
                new
                {
                    Musteri = x.Musteri.ad,
                    Kullanici = x.Kullanici.ad,
                    Tur = x.Tur.ad,
                    Marka = x.Marka.ad,
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
            cmbPersonel.Text = "";
            rchtxtAciklama.Text = "";
            cmbDurum.Text = "";
            cmbPersonel.Focus();
            #endregion
        }

        private void frmArizaBitir_Load(object sender, EventArgs e)
        {
            ListeleKayit();
            Temizle();

            #region Personel adlarini combobox da listeletme
            var listePersonel = db.Kullanici.Where(x=>x.yetkiID==2).Select(x => new
            {
                x.kullaniciID,
                eposta = x.eposta
            }
            ).ToList();
            cmbPersonel.DataSource = listePersonel;
            cmbPersonel.DisplayMember = "eposta";
            cmbPersonel.ValueMember = "kullaniciID";
            #endregion
        }

        private void gridArizaListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Grid'de seçilen satırı textbox lara geçirme.
            cmbPersonel.Text = gridArizaListe.SelectedRows[0].Cells[1].Value.ToString();
            rchtxtAciklama.Text = gridArizaListe.SelectedRows[0].Cells[9].Value.ToString();
            cmbDurum.Text = gridArizaListe.SelectedRows[0].Cells[10].Value.ToString();
            #endregion
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            #region Duzenleme islemi
            if (cmbPersonel.Text == "" && rchtxtAciklama.Text == "" && cmbDurum.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kayit k = db.Kayit.Where(x => x.Kullanici.eposta == cmbPersonel.Text).SingleOrDefault();
                var PersonelID = db.Kullanici.Where(x => x.eposta == cmbPersonel.Text).Select(x => x.kullaniciID).SingleOrDefault();
                k.kullaniciID = PersonelID;
                k.aciklama = rchtxtAciklama.Text;
                k.durum = Convert.ToBoolean(cmbDurum.Text);
                db.SaveChanges();
                ListeleKayit();
                Temizle();
                MessageBox.Show("Başarıyla Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmAnasayfa frm = new frmAnasayfa();
            this.Hide();
            frm.Show();
        }
    }
}
