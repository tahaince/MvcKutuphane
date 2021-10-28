using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OgrenciKitapController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: OgrenciKitap
        public ActionResult Index()
        {
            
            var kitap = db.TBL_KITAP.Where(x => x.DURUM == true).ToList();

            return View(kitap);
        }

        public ActionResult Kitaplarim()
        {
            var uye = (string)Session["MAIL"];
            var id= db.TBL_UYELER.Where(x=>x.MAIL==uye.ToString()).Select(z=>z.ID).FirstOrDefault();
            var kitap = db.TBL_HAREKET.Where(y => y.UYE ==id).ToList();
            return View(kitap);

        }
    }
}