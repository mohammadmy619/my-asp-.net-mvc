using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaayer
{
    public interface IpageAdmin
    {
        bool IsExistUser(string username, string password);

    }
}
