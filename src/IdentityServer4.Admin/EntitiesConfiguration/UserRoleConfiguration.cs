using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer4.Admin.EntitiesConfiguration
{
    public class UserRoleConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(x => new {x.RoleId,x.UserId });
          
        }
    }
}
