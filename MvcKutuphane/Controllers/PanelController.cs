using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();


        // GET: Panel
        public ActionResult Index()
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
            return View(degerler);
        }
      

        public ActionResult Index2(TBL_UYELER p)
        {

            var kullanıci = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanıci);
            uye.SIFRE = p.SIFRE;
            db.SaveChanges();
            return RedirectToAction("GirisYap", "Login");

        }


        public ActionResult Duyuru()
        {
            getdata();
            var duyuru = db.TBL_DUYURU.ToList();

            return View(duyuru);
        }

        public ActionResult Kitap(string p)
        {

            getdata();


            var kitap = from x in db.TBL_KITAP select x;
            if (!string.IsNullOrEmpty(p))
            {
                kitap = kitap.Where(m => m.AD.Contains(p));
            }
            return View(kitap.ToList());
        }

        public ActionResult Kitaplarim()
        {
            getdata();
            var uye = (string)Session["MAIL"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == uye.ToString()).Select(z => z.ID).FirstOrDefault();
            var kitap = db.TBL_HAREKET.Where(y => y.UYE == id).ToList();
            return View(kitap);

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
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}