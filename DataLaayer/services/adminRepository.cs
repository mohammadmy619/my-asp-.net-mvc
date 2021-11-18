using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaayer
{
   public class adminRepository:IpageAdmin
    {

       private mycmscontext db;

       public adminRepository (mycmscontext context)
       	{
           db = context;
     	}
      
       public bool IsExistUser(string username, string password)
       {
           return db.adminlogins.Any(u => u.UserName == username && u.Password == password);
       }
    }
}
