using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer4.Admin.EntitiesConfiguration
{
    public class IdentityResourcesConfiguration : IEntityTypeConfiguration<IdentityResource>
    {
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(1,1);
        }
    }
}
