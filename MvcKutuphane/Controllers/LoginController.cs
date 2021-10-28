using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{

    public class LoginController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        [HttpGet]
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if(bilgiler!=null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["MAIL"] = bilgiler.MAIL.ToString();
                TempData["AD"] = bilgiler.AD.ToString();
                TempData["SOYAD"] = bilgiler.SOYAD.ToString();
                TempData["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();
                TempData["TELEFON"] = bilgiler.TELEFON.ToString();
                TempData["OKUL"] = bilgiler.OKUL.ToString();
                TempData["FOTO"] = bilgiler.FOTOGRAF.ToString();
                TempData["SIFRE"] = bilgiler.SIFRE.ToString();
                return RedirectToAction("Index", "Panel");
            }
            return View();
        }
    }
}