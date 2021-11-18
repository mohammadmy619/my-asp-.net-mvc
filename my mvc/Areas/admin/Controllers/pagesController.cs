using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLaayer;
using System.Globalization;


namespace my_mvc.Areas.admin.Controllers
{
    [Authorize]
    public class pagesController : Controller
    {
       private IPageRepository pageRepository;
        //private IPageRepository pageRepository;
        private IPageGroupRepository pageGroupRepository;

        private mycmscontext db = new mycmscontext();

        public pagesController()
        {
            pageGroupRepository = new pagegrouprepository(db);
            pageRepository = new PageRepository(db);
        }
        ////public pagesController()
        //{
        //    pageGroupRepository = new pagegrouprepository(db);
        //    pageRepository = new 
        //    //PageRepository=new pager
        //}

        // GET: admin/pages
     
        public ActionResult Index()
        {
            var pages = db.pages.Include(p => p.PageGroup);
            return View(pageRepository.GetAllPage());
        }

        // GET: admin/pages/Details/5
        public ActionResult Details(int? di)
        {
            if (di == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = db.pages.Find(di);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: admin/pages/Create
        public ActionResult Create()
        {
            //ViewBag.GroupID = new SelectList(db.pagegroup, "GroupID", "GroupTitle");
            ViewBag.GroupID = new SelectList(pageGroupRepository.getallgroups(),"GroupID","GroupTitle");

            return View();
        }

        // POST: admin/pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate,Tages")] page page,HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;
                if (imgup!=null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));

                }
                pageRepository.InsertPage(page);
                pageRepository.Save();
                //db.pages.Add(page);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.pagegroup, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: admin/pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.getallgroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: admin/pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate")] page page ,HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                if (imgup != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
                    }
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));

                }
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                //db.Entry(page).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.pagegroup, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: admin/pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = db.pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: admin/pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.GetPageById(id);
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
            }
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
            //page page = db.pages.Find(id);
            //db.pages.Remove(page);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                pageRepository.Dispose();
                db.Dispose();
               
                
            }
            base.Dispose(disposing);
        }
    }
}
