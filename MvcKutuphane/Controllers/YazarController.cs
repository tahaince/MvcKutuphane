using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            var degerler = db.TBL_YAZARLAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TBL_YAZARLAR p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_YAZARLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
          var yazar=  db.TBL_YAZARLAR.Find(id);
            db.TBL_YAZARLAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TBL_YAZARLAR.Find(id);
           
            return View ("YazarGetir",yazar);
        }

        public ActionResult YazarGuncelle(TBL_YAZARLAR p)
        {
            var yazar = db.TBL_YAZARLAR.Find(p.ID);
            yazar.AD = p.AD; 
            yazar.SOYAD = p.SOYAD;
            yazar.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
            
            
        }

    }
}