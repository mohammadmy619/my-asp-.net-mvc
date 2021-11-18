using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLaayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<page> GetAllPage();
        page GetPageById(int pageId);
        bool InsertPage(page page);
        bool UpdatePage(page page);
        bool DeletePage(page page);
        bool DeletePage(int pageId);
        void Save();
        IEnumerable<page> topnew(int take = 4);
        IEnumerable<page> slider();
        IEnumerable<page> PagesInSlider();
        IEnumerable<page> lastnews(int take = 4);
        IEnumerable<page> ShowPageByGroupId(int groupId);
        IEnumerable<page> searchpages(string search);





    }
}
