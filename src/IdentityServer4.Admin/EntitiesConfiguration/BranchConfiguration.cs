using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer4.Admin.EntitiesConfiguration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch"); //表名
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever(); //不要自动生成
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.HasMany(x => x.Users).WithOne(x => x.Branch);
            builder.HasMany<Role>(x => x.Roles).WithOne(x => x.Branch);

        }
    }
}
