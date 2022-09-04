namespace Teknik_Sevis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class İslemTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public İslemTur()
        {
            İslem = new HashSet<İslem>();
        }

        [Key]
        public int islemTurID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        public decimal? ucret { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<İslem> İslem { get; set; }
    }
}
