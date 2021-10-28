using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: KayitOl
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(TBL_UYELER p)
        {
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("/Vitrin/Index/");
        }
    }
}