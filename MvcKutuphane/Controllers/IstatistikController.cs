using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.sınıflar;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Istatistik
        [HttpGet]
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            ViewBag.dgr1 = deger1;

            var deger2 = db.TBL_KITAP.Count();
            ViewBag.dgr2 = deger2;

            var deger3 = db.TBL_HAREKET.Count();
            ViewBag.dgr3 = deger3;
            Class2 cs = new Class2();

            cs.deger5 = db.TBL_HAKKINDA.ToList();


            return View(cs);
        }
        public ActionResult Guncelle(TBL_HAKKINDA p)
        {
            var hak= db.TBL_HAKKINDA.Find(p.ID);
            hak.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Guncelle2(TBL_HAKKINDA p)
        {
            var hak = db.TBL_HAKKINDA.Find(p.ID);
            hak.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Ekle()
        {

         
            return View();



        }


        [HttpPost]
        public ActionResult Ekle(TBL_HAKKINDA p)
        {

            db.TBL_HAKKINDA.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}