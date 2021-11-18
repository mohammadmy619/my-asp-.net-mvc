using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLaayer;
using System.Security;
using System.Web.Security;

namespace my_mvc.Controllers
{
    public class accountController : Controller
    {
        private IpageAdmin adminRepository;

       private mycmscontext db = new mycmscontext();
        public accountController()
        {
            adminRepository = new adminRepository(db);
        }
        // GET: account
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(admiModel login)
        {
            if (ModelState.IsValid)
            {

           
            
                if (adminRepository.IsExistUser(login.UserName, login.Password))
            
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect("/");


                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}