using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.sınıflar;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class MesajController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Mesaj
        public ActionResult Index()
        {
            getdata();
            var uye = (string)Session["MAIL"].ToString();
            var mesaj = db.TBL_MESAJLAR.Where(x => x.ALICI == uye.ToString()).ToList();
            return View(mesaj);

        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            getdata();

            var uyemail = (string)Session["MAIL"].ToString();
            ViewBag.dgr1 = uyemail;


            return View();
        }


        [HttpPost]
        public ActionResult YeniMesaj(TBL_MESAJLAR p)
        {
            getdata();
            if (!ModelState.IsValid)
            {
                return View("YeniMesaj");
            }
            var uyemail = (string)Session["MAIL"].ToString();
            p.GONDEREN = uyemail;
            db.TBL_MESAJLAR.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GidenMesaj ()
        {
            getdata();

            var uye = (string)Session["MAIL"].ToString();
            var mesaj = db.TBL_MESAJLAR.Where(x => x.GONDEREN == uye.ToString()).ToList();
            return View(mesaj);

        }

        public ActionResult getdata()
        {


            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var deger1 = degerler.AD;
            var deger2 = degerler.SOYAD;
            var deger3 = degerler.MAIL;
            var deger4 = degerler.FOTOGRAF;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
    }

}