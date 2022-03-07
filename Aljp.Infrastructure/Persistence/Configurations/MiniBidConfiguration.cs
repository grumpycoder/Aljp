using Aljp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class MiniBidConfiguration: IEntityTypeConfiguration<MiniBid>
{
    public void Configure(EntityTypeBuilder<MiniBid> builder)
    {
        builder.ToTable("MiniBids", schema: "Common");
        builder.Property(p => p.Id).HasColumnName("MiniBidId");
        builder.Property(p => p.Description).HasColumnName("ProjectDescription");
    }
}
