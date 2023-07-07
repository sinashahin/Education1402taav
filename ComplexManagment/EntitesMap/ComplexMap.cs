using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ComplexManagment.Entities;

namespace ComplexManagment.EntitesMap
{
    public class ComplexMap : IEntityTypeConfiguration<Complex>
    {
        public void Configure(EntityTypeBuilder<Complex> builder)
        {
            builder.ToTable("Complexs");
            builder.HasKey(_ => _.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.UnitCount).IsRequired();
        }
    }
}
