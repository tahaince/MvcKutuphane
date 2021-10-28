using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.sınıflar;

namespace MvcKutuphane.Models.sınıflar
{
    public class Class2
    {
        public IEnumerable<TBL_KITAP> deger1 { get; set; }
        public IEnumerable<TBL_UYELER> deger2 { get; set; }
        public IEnumerable<TBL_KASA> deger3 { get; set; }
        public IEnumerable<TBL_ILETISIM> deger4 { get; set; }
        public IEnumerable<TBL_HAKKINDA> deger5 { get; set; }
    }
}