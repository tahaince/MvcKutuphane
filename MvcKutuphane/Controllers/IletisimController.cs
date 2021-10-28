using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    
    public class IletisimController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Iletisim
        public ActionResult Index()   
        {
            var iletisim = db.TBL_ILETISIM.ToList();

            return View(iletisim);
        }
    }
}