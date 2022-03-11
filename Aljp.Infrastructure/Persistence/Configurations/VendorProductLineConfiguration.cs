using Aljp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class VendorProductLineConfiguration : IEntityTypeConfiguration<VendorProductLine>
{
    public void Configure(EntityTypeBuilder<VendorProductLine> builder)
    {
        builder.ToTable("VendorProductLines", schema: "Common");
        // builder.Property(p => p.Id).HasColumnName("VendorProductLineId");
      
        builder.HasKey(line => new { line.VendorId, line.ProductLineId });
    }
}