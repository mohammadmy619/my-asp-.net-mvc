using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaayer
{
    public class commentrepository : IpageCommentRepository
    {
        private mycmscontext db;

        public commentrepository(mycmscontext context)
        {
            db = context;
        }
        public bool addcomment(pagecamment comment)
        {
            try
            {
                db.pagecomments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<pagecamment> getcommentbynewsid(int pageid)
        {
            return db.pagecomments.Where(c => c.PageID == pageid);

        }
    
       }
}
