using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Entities
{
    public  class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
