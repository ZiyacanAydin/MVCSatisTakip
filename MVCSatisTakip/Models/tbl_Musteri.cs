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
    
    public partial class tbl_Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Musteri()
        {
            this.tbl_Satis = new HashSet<tbl_Satis>();
        }
    
        public int musteriId { get; set; }
        public string musteriAd { get; set; }
        public string musteriTel { get; set; }
        public string musteriTc { get; set; }
        public string musteriAdres { get; set; }
        public string musteriMeslek { get; set; }
        public string musteriSehir { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Satis> tbl_Satis { get; set; }
    }
}
