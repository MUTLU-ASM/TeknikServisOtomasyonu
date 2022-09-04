namespace Teknik_Sevis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class İslem
    {
        [Key]
        public int islemID { get; set; }

        public int? kayitID { get; set; }

        public int? islemTurID { get; set; }

        public int? kullaniciID { get; set; }

        [Column(TypeName = "text")]
        public string aciklama { get; set; }

        [Column(TypeName = "date")]
        public DateTime? islemTarihi { get; set; }

        public decimal? ucret { get; set; }

        public virtual İslemTur İslemTur { get; set; }

        public virtual Kayit Kayit { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
