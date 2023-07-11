using ComplexManagment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.EntitesMap
{
    public class ComplexUsageTypeMap : IEntityTypeConfiguration<ComplexUsageType>
    {
        public void Configure(EntityTypeBuilder<ComplexUsageType> builder)
        {
            builder.ToTable("ComplexUsageTypes");
            builder.HasKey(_ => new
            {
                _.ComplexId,
                _.UsageTypeId
            });

        }
    }
}
