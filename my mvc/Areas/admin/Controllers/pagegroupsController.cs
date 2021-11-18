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
    public class pagegroupsController : Controller
    {
      
        //private mycmscontext db = new mycmscontext();
        private IPageGroupRepository PageGroupRepository;
        mycmscontext db=new mycmscontext();
         public pagegroupsController()
         {
             PageGroupRepository = new pagegrouprepository(db);
         }
        
        

        // GET: admin/pagegroups
        public ActionResult Index()
        {
            return View(PageGroupRepository.getallgroups());
        }

        // GET: admin/pagegroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = PageGroupRepository.getgroupbyid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return View(pagegroup);
        }

        // GET: admin/pagegroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: admin/pagegroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] pagegroup pagegroup)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepository.insertgroup(pagegroup);
                PageGroupRepository.seve();
                
                return RedirectToAction("Index");
            }

            return View(pagegroup);
        }

        // GET: admin/pagegroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = PageGroupRepository.getgroupbyid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return View(pagegroup);
        }

        // POST: admin/pagegroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] pagegroup pagegroup)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepository.updategroup(pagegroup);
                PageGroupRepository.seve();
                return RedirectToAction("Index");
            }
            return PartialView(pagegroup); 
        }

        // GET: admin/pagegroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = PageGroupRepository.getgroupbyid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pagegroup);
        }

        // POST: admin/pagegroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageGroupRepository.Deletegroup(id);
            PageGroupRepository.seve();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
