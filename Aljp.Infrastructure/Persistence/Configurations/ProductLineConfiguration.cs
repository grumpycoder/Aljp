using Aljp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class ProductLineConfiguration : IEntityTypeConfiguration<ProductLine>
{
    public void Configure(EntityTypeBuilder<ProductLine> builder)
    {
        builder.ToTable("ProductLines", schema: "Common");
        builder.Property(p => p.Id).HasColumnName("ProductLineId");
        builder.Property(p => p.Name).HasColumnName("ProductLineName");
    }
}