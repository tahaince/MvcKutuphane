using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitap = from x in db.TBL_KITAP select x;
                        if(!string.IsNullOrEmpty(p))
            {
                kitap = kitap.Where(m => m.AD.Contains(p));
            }

            
          
            return View(kitap.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }
                                         ).ToList();
            ViewBag.dgr1 = deger1;



            List<SelectListItem> deger2 = (from i in db.TBL_YAZARLAR.ToList()

                                           select new SelectListItem
                                           {
                                               Text = i.AD +' '+i.SOYAD,
                                               Value = i.ID.ToString()


                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBL_KITAP p)
        {
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yzr = db.TBL_YAZARLAR.Where(y => y.ID == p.TBL_YAZARLAR.ID).FirstOrDefault();
            p.TBL_KATEGORI = ktg;
            p.TBL_YAZARLAR = yzr;
            p.DURUM = true;
            db.TBL_KITAP.Add(p);
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var ktp = db.TBL_KITAP.Find(id);
            db.TBL_KITAP.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");



        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBL_KITAP.Find(id);


            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }
                                       ).ToList();
            ViewBag.dgr1 = deger1;



            List<SelectListItem> deger2 = (from i in db.TBL_YAZARLAR.ToList()

                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()


                                           }).ToList();
            ViewBag.dgr2 = deger2;



            return View("KitapGetir",ktp);



        }

        public ActionResult KitapGuncelle(TBL_KITAP p)
        {
            var kitap = db.TBL_KITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.YIL = p.YIL;
            kitap.SAYFA =p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yzr = db.TBL_YAZARLAR.Where(y => y.ID == p.TBL_YAZARLAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            db.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}