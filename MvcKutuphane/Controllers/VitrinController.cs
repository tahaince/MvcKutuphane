using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.sınıflar;

namespace MvcKutuphane.Controllers
{

    public class VitrinController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Vitrin
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TBL_KITAP.ToList();
            cs.deger2 = db.TBL_HAKKINDA.Where(x=>x.DURUM==true).ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM p)
        { 
            db.TBL_ILETISIM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}