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
    public partial class frmYoneticiSayfasi : Form
    {
        public frmYoneticiSayfasi()
        {
            InitializeComponent();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            frmPersonelIslemleri frm = new frmPersonelIslemleri();
            this.Hide();
            frm.Show();
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmAnasayfa frm = new frmAnasayfa();
            this.Hide();
            frm.Show();
        }

        private void btnMarkaTur_Click(object sender, EventArgs e)
        {
            frmMarkaTurIslem frm = new frmMarkaTurIslem();
            this.Hide();
            frm.Show();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
