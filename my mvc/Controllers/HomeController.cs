using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLaayer;
namespace my_mvc.Controllers
{
    public class HomeController : Controller
    {
        mycmscontext db = new mycmscontext();
        private IPageRepository pageRepository;

        public HomeController()
        {
            pageRepository = new PageRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult slider()
        {
            //return PartialView(PageRepository.PagesInSlider());
            return PartialView(pageRepository.PagesInSlider());

        }
        public ActionResult lastnews()
        {
            return PartialView(pageRepository.lastnews());

        }
    }
}