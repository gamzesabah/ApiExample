using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.Options;

namespace Core.Utilities.Security
{
    public class LoggedInUsers
    {
        public LoggedInUsers()
        {
            UserInfo = new List<UserInfo>();
        }
        public List<UserInfo> UserInfo { get; set; }
    }
}
