using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer4.Admin.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasOne<Branch>().WithMany(x => x.Roles)
                   .HasForeignKey(x => x.BranchId);

            builder.Property(x => x.BranchId).IsRequired().HasDefaultValue(0);
            builder.HasQueryFilter(x => x.Name != "Administrator");
        }
    }
}
