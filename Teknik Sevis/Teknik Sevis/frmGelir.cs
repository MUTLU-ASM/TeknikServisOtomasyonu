using System;
using System.Collections;
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
    public partial class frmGelir : Form
    {
        public frmGelir()
        {
            InitializeComponent();
        }
        TeknikServisDbContext db = new TeknikServisDbContext();
        private void frmGelir_Load(object sender, EventArgs e)
        {

        }
    }
}
