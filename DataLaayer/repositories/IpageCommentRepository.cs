using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaayer
{
    public interface IpageCommentRepository
    {
        IEnumerable<pagecamment> getcommentbynewsid(int pageid);
        bool addcomment(pagecamment comment);
        

    }
}
