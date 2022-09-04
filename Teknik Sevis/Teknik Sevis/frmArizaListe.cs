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
    public partial class frmArizaListe : Form
    {
        public frmArizaListe()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        public void ListeleAriza()
        {
            #region GridView Listeleme
            //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
            //gridKayit dan istediğimiz bilgileri listeletme
            gridArizaListe.DataSource = db.Kayit.Select(x =>
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

        private void frmArizaListe_Load(object sender, EventArgs e)
        {
            ListeleAriza();
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmAnasayfa frm = new frmAnasayfa();
            this.Hide();
            frm.Show();
        }

        private void chcTamamlanmisAriza_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox a tıklanması durumunda GridView Listeleme
            if (chcTamamlanmisAriza.Checked==true)
            {
                #region GridView arıza tamamlanmış olanları Listeleme
                //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
                //gridKayit dan istediğimiz bilgileri listeletme
                gridArizaListe.DataSource = db.Kayit.Where(x => x.durum == true).Select(x =>
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
            else if (true)
            {
                #region GridView Listeleme
                //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
                //gridKayit dan istediğimiz bilgileri listeletme
                gridArizaListe.DataSource = db.Kayit.Select(x =>
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
            #endregion
        }

        private void chcTamamlanmamıs_CheckedChanged(object sender, EventArgs e)
        {
            #region checkbox a tıklanması durumunda GridView Listeleme
            if (chcTamamlanmamıs.Checked == true)
            {
                #region GridView arıza tamamlanmamış olanları Listeleme
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
            else if (true)
            {
                #region GridView Listeleme
                //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
                //gridKayit dan istediğimiz bilgileri listeletme
                gridArizaListe.DataSource = db.Kayit.Select(x =>
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
            #endregion
        }
    }
}
