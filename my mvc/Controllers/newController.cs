using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLaayer;

namespace my_mvc.Controllers
{
    public class newController : Controller
    {
         mycmscontext db = new mycmscontext();
        private IPageGroupRepository pagegrouprepository;
        private PageRepository PageRepository;
        private IpageCommentRepository pageCommentRepository;
        public newController()
        {
            pagegrouprepository = new pagegrouprepository(db);

            PageRepository = new PageRepository(db);
            pageCommentRepository = new commentrepository(db);
        }
        // GET: new
        public ActionResult Index()
        {
            return PartialView(pagegrouprepository.GetGroupsForView());
        }
        public ActionResult showgropsinmenu()
        {
            return PartialView(pagegrouprepository.getallgroups());
        }
        public ActionResult topnews()
        {
            return PartialView(PageRepository.topnew());
        }
        [Route("archive")]
        public ActionResult archivenews()
        {
            return View(PageRepository.GetAllPage());

        }
        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            //return View(PageRepository.ShowPageByGroupId(id));
            return View(PageRepository.ShowPageByGroupId(id));
        }
        [Route("new/{id}")]
        public ActionResult shownews(int id)
        {
            var news = PageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            news.Visit += 1;
            PageRepository.UpdatePage(news);
            PageRepository.Save();

            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            pagecamment addcomment = new pagecamment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Email = email,
                Name = name
            };
            pageCommentRepository.addcomment(addcomment);
            return PartialView("showcomments", pageCommentRepository.getcommentbynewsid(id));

            //return PartialView("ShowComments", pageCommentRepository.GetCommentByNewsId(id));
        }
        public ActionResult showcomments(int id)
        {
            return PartialView(pageCommentRepository.getcommentbynewsid(id));
        }
        //public ActionResult addcomment(int id,string name, string email, string comment)
        //{
        //    pagecamment addcomment = new pagecamment
        //    {
        //        CreateDate= DateTime.Now,
        //        PageID=id,
        //        Comment=comment,
        //        Email=email,
        //        Name=name

        //    };
        //    pageCommentRepository.addcomment(addcomment);
        //    return null;
        //}
    }
}