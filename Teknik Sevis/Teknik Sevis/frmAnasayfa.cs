using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Teknik_Sevis.Models;

namespace Teknik_Sevis
{
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }

        TeknikServisDbContext db = new TeknikServisDbContext();

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriKayit_Click(object sender, EventArgs e)
        {
            frmMusteriKayit frm = new frmMusteriKayit();
            this.Hide();
            frm.Show();
        }

        private void btnArizaKayit_Click(object sender, EventArgs e)
        {
            frmArizaKayit frm = new frmArizaKayit();
            this.Hide();
            frm.Show();
        }
        private void btnArizaListe_Click_1(object sender, EventArgs e)
        {
            frmArizaListe frm = new frmArizaListe();
            this.Hide();
            frm.Show();
        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            #region GridView arızalı olanları Listeleme
            //gridKayit.DataSource = db.Bilet.ToList(); tümünü listelemek için.
            //gridKayit dan istediğimiz bilgileri listeletme
            gridAriza.DataSource = db.Kayit.Where(x => x.durum == false).Select(x =>
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

            #region Doviz xml islemleri
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            txtTL.Text = dolaralis;
            #endregion
        }

        private void btnArızaBitir_Click(object sender, EventArgs e)
        {
            frmArizaBitir frm = new frmArizaBitir();
            this.Hide();
            frm.Show();
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            frmHesapMakine frm = new frmHesapMakine();
            this.Hide();
            frm.Show();
        }

        private void btnUSDcevir_Click_1(object sender, EventArgs e)
        {
            #region Doviz USD - TL çevirme islemleri
            String bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            txtTL.Text = dolaralis;

            double usd, tl, tutar;
            usd = Convert.ToDouble(txtUSD.Text);
            tl = Convert.ToDouble(txtTL.Text);
            tutar = tl * usd;
            txtTL.Text = tutar.ToString();
            #endregion
        }

        private void btnTLcevir_Click(object sender, EventArgs e)
        {
            #region Doviz TL - USD çevirme islemleri
            String bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;

            double usd, tl, tutar;
            usd = Convert.ToDouble(dolaralis);
            tl = Convert.ToDouble(txtTL.Text);
            tutar = usd/tl;
            txtUSD.Text = tutar.ToString();
            #endregion
        }
    }
}
