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
    using System.Collections.Generic;
    
    public partial class tbl_Satis
    {
        public int satisId { get; set; }
        public Nullable<decimal> satisFiyat { get; set; }
        public Nullable<int> satisAdet { get; set; }
        public Nullable<System.DateTime> satisTarih { get; set; }
        public Nullable<int> urunId { get; set; }
        public Nullable<int> musteriId { get; set; }
    
        public virtual tbl_Musteri tbl_Musteri { get; set; }
        public virtual tbl_Urun tbl_Urun { get; set; }
    }
}
