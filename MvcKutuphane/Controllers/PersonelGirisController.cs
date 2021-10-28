using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{

    public class PersonelGirisController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: PersonelGiris
        [HttpGet]
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBL_PERSONEL p)
        {
            var bilgiler = db.TBL_PERSONEL.FirstOrDefault(x => x.ADSOYAD == p.ADSOYAD && x.ID == p.ID);
         

              
                Session["ADSOYAD"] = bilgiler.ADSOYAD.ToString();
               
                return RedirectToAction("Index", "Kitap");
            
            return View();
        }
    }
}