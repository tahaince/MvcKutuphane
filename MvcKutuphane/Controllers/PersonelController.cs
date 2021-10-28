using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{

    public class PersonelController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var prs = db.TBL_PERSONEL.ToList();

            return View(prs);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONEL p)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            db.TBL_PERSONEL.Add(p);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var prs = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(prs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBL_PERSONEL.Find(id);
  

            return View("PersonelGetir",prs);
        }

        public ActionResult PersonelGuncelle(TBL_PERSONEL p)
        {
            var prs = db.TBL_PERSONEL.Find(p.ID);
            prs.ADSOYAD = p.ADSOYAD;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}