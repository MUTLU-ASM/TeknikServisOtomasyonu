using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Teknik_Sevis.Models
{
    public partial class TeknikServisDbContext : DbContext
    {
        public TeknikServisDbContext()
            : base("name=TeknikServisDbContext4")
        {
        }

        public virtual DbSet<İslem> İslem { get; set; }
        public virtual DbSet<İslemTur> İslemTur { get; set; }
        public virtual DbSet<Kayit> Kayit { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tur> Tur { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Yonetici> Yonetici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<İslem>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Kayit>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Yonetici>()
                .Property(e => e.telefon)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
