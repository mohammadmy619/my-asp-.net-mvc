using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLaayer;
namespace my_mvc.Controllers
{
    public class serachController : Controller
    {
        IPageRepository pageRepository;
        mycmscontext db = new mycmscontext();
        public serachController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: serach
        public ActionResult Index(string q)
        {
            ViewBag.neme = q;
            return View(pageRepository.searchpages(q));
        }
    }
}