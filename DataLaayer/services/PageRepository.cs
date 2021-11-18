using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLaayer
{
    public class PageRepository : IPageRepository
    {
        public mycmscontext db;
        public PageRepository(mycmscontext context)
        {
            this.db = context;
        }

        public IEnumerable<page> GetAllPage()
        {
            return db.pages;
        }

        public page GetPageById(int pageId)
        {
            return db.pages.Find(pageId);

        }

        public bool InsertPage(page page)
        {
            //return db.pages.Add(page);
            try
            {
                db.pages.Add(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdatePage(page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeletePage(page page)
        {
            try
            {


                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeletePage(int pageId)
        {
            try
            {
                var page = GetPageById(pageId);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }


        public IEnumerable<page> topnew(int take = 4)
        {
            return db.pages.OrderByDescending(p => p.Visit).Take(take);
        }


        public IEnumerable<page> slider()
        {
            return db.pages.Where(p => p.ShowInSlider == true);
        }
        public IEnumerable<page> PagesInSlider()
        {
            return db.pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<page> lastnews(int take = 4)
        {
            return db.pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<page> ShowPageByGroupId(int groupId)
        {
            return db.pages.Where(p => p.GroupID == groupId);
        }

        public IEnumerable<page> searchpages(string search)
        {
            return db.pages.Where(p => 
            p.Title.Contains(search) || p.ShortDescription.Contains(search) || p.ShortDescription.Contains(search)
            || p.Tages.Contains(search) || p.Text.Contains(search)).Distinct();
        }
    }
}
