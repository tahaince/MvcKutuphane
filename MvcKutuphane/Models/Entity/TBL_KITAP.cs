//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_KITAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_KITAP()
        {
            this.TBL_HAREKET = new HashSet<TBL_HAREKET>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public Nullable<int> KATEGORI { get; set; }
        public Nullable<int> YAZAR { get; set; }
        public string YIL { get; set; }
        public string YAYINEVI { get; set; }
        public string SAYFA { get; set; }
        public Nullable<bool> DURUM { get; set; }
        public string RESIM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_HAREKET> TBL_HAREKET { get; set; }
        public virtual TBL_KATEGORI TBL_KATEGORI { get; set; }
        public virtual TBL_YAZARLAR TBL_YAZARLAR { get; set; }
    }
}
