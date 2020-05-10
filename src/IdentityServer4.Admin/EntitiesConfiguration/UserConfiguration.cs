using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer4.Admin.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasIndex(u => u.CreationTime);
            builder.HasOne<Branch>(x => x.Branch) //一个用户一个branch 一个branch包含多个用户
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(deleteBehavior:DeleteBehavior.NoAction); 
          

            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.HasQueryFilter(x => x.IsDelete == false);
        }
    }
}
