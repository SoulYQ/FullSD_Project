using FullSD_Project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullSD_Project.Server.Configurations.Entities
{
    public class BrandSeedConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Milwaukee",
                    DateCreated = DateTime.Now.AddMonths(-3),
                    DateUpdated = DateTime.Now.AddMonths(-3),
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Brand
                {
                    Id = 2,
                    Name = "RIDGID",
                    DateCreated = DateTime.Now.AddMonths(-3),
                    DateUpdated = DateTime.Now.AddMonths(-3),
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new State
                {
                    Id = 3,
                    Name = "MAKITA",
                    DateCreated = DateTime.Now.AddMonths(-3),
                    DateUpdated = DateTime.Now.AddMonths(-3),
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );
        }
    }
}
