//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSatisTakip.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SatisTakipEntities : DbContext
    {
        public SatisTakipEntities()
            : base("name=SatisTakipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Kategori> tbl_Kategori { get; set; }
        public virtual DbSet<tbl_Musteri> tbl_Musteri { get; set; }
        public virtual DbSet<tbl_Satis> tbl_Satis { get; set; }
        public virtual DbSet<tbl_Urun> tbl_Urun { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
    }
}
