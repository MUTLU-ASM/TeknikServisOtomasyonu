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
    public partial class frmGecisEkrani : Form
    {
        public frmGecisEkrani()
        {
            InitializeComponent();
        }

        private void tmrYuklenmeSuresi_Tick(object sender, EventArgs e)
        {
            panel2.Width += 1;
            if (panel2.Width >= 380)
            {
                tmrYuklenmeSuresi.Stop();
                frmGiris frm = new frmGiris();
                this.Hide();
                frm.Show();
            }
        }

        private void frmGecisEkrani_Load(object sender, EventArgs e)
        {

        }
    }
}
