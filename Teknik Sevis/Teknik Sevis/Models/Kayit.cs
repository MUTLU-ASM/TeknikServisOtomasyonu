namespace Teknik_Sevis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kayit")]
    public partial class Kayit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kayit()
        {
            İslem = new HashSet<İslem>();
        }

        public int kayitID { get; set; }

        public int? musteriID { get; set; }

        public int? kullaniciID { get; set; }

        public int? turID { get; set; }

        public int? markaID { get; set; }

        [StringLength(50)]
        public string model { get; set; }

        [StringLength(50)]
        public string sorun { get; set; }

        [Column(TypeName = "date")]
        public DateTime? alisTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? teslimTarihi { get; set; }

        public decimal? tutar { get; set; }

        [Column(TypeName = "text")]
        public string aciklama { get; set; }

        public bool? durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<İslem> İslem { get; set; }

        public virtual Marka Marka { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Tur Tur { get; set; }
    }
}
