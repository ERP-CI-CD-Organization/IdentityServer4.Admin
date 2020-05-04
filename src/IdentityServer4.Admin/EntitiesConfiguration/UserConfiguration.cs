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
            builder.HasIndex(u => u.CreationTime);
            builder.HasOne(x => x.Branch) //一个用户一个branch 一个branch包含多个用户
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.BranchId);
            
            builder.Property(x => x.BranchId)
                   .HasDefaultValue(0)
                   .HasColumnName("BranchId");//没有指定的话，值为0

            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.HasQueryFilter(x => x.IsDelete == false);
        }
    }
}
