namespace Teknik_Sevis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yonetici")]
    public partial class Yonetici
    {
        public int yoneticiID { get; set; }

        public int? yetkiID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        [StringLength(11)]
        public string telefon { get; set; }

        public virtual Yetki Yetki { get; set; }
    }
}
