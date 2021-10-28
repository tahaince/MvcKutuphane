using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
   
    public class OduncController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var hrkt = db.TBL_HAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(hrkt);
     
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from i in db.TBL_UYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }
                                    ).ToList();
            ViewBag.dgr1 = deger1;



            List<SelectListItem> deger2 = (from y in db.TBL_KITAP.ToList()

                                           select new SelectListItem
                                           {
                                               Text = y.AD,
                                               Value = y.ID.ToString()


                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();

        }

        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {

          
            var uye = db.TBL_UYELER.Where(k => k.ID == p.TBL_UYELER.ID).FirstOrDefault();
            var ktp = db.TBL_KITAP.Where(y => y.ID == p.TBL_KITAP.ID).FirstOrDefault();
            p.TBL_UYELER = uye;
            p.TBL_KITAP = ktp;

            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

       

        public ActionResult Odunciade(int id)
        {
            var hrkt = db.TBL_HAREKET.Find(id);
            return View("Odunciade",hrkt);

        }
        public ActionResult OduncGuncelle(TBL_HAREKET p)
        {

            var hrkt = db.TBL_HAREKET.Find(p.ID);
            hrkt.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrkt.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}