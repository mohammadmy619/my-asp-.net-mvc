using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLaayer
{
   public class mycmscontext:DbContext
    {
        public DbSet<pagegroup> pagegroup { get; set; }
        public DbSet<page> pages { get; set; }
        public DbSet<pagecamment> pagecomments { get; set; }
        public DbSet<adminlogin> adminlogins { get; set; }

    }
}
