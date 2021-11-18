using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataLaayer
{
    public class pagegrouprepository:IPageGroupRepository
    {
         private mycmscontext db;
         public pagegrouprepository(mycmscontext context)
        {
            this.db=context;
        }
        public IEnumerable<pagegroup> getallgroups()
        {
            return db.pagegroup;
        }

        public pagegroup getgroupbyid(int groupid)
        {
            return db.pagegroup.Find(groupid);
        }

        public bool insertgroup(pagegroup pagegroup)
        {
            try
            {
                db.pagegroup.Add(pagegroup);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool updategroup(pagegroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Deletegroup(pagegroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State = EntityState.Deleted;
                ////db.Entry(pagegroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool Deletegroup(int pagegroup)
        {

            try
            {
                var group = getgroupbyid(pagegroup);
                Deletegroup(group);
                //var group = GetGroupById(groupId);
                //DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

            
        }

        public void seve()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }





        public IEnumerable<showgroup> GetGroupsForView()
        {
            return db.pagegroup.Select(g =>new showgroup(){
              GroupID=g.GroupID,
              GroupTitle=g.GroupTitle,
                             PageCount = g.Pages.Count

            });
        }
    }
}
