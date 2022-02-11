using FullSD_Project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullSD_Project.Server.Configurations.Entities
{
    public class StateSeedConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                new State
                {
                    Id = 1,
                    Name = "90% NEW",
                    DateCreated = DateTime.Now.AddMonths(-3),
                    DateUpdated = DateTime.Now.AddMonths(-3),
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new State
                {
                    Id = 2,
                    Name = "NEW",
                    DateCreated = DateTime.Now.AddMonths(-3),
                    DateUpdated = DateTime.Now.AddMonths(-3),
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new State
                {
                    Id = 3,
                    Name = "Small area scratches",
                    DateCreated = DateTime.Now.AddMonths(-3),
                    DateUpdated = DateTime.Now.AddMonths(-3),
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );
        }
    }
}
