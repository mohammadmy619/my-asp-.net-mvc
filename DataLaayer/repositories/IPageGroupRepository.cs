using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaayer
{
    public interface IPageGroupRepository : IDisposable
    {
         IEnumerable<pagegroup> getallgroups();
         pagegroup getgroupbyid(int groupid);

         bool insertgroup(pagegroup pagegroup);
         bool updategroup(pagegroup pagegroup);

         bool Deletegroup(pagegroup pagegroup);

         bool Deletegroup(int pagegroup);

         void seve();
         IEnumerable<showgroup> GetGroupsForView();




    }
}
