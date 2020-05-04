using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Infrastructure
{
    public static class BaseRoleList
    {
       
        public static  List<string> RoleList = new List<string>()
        {
            "Administrator","系统管理员","销售员","采购员",
        };
        
    }
}
