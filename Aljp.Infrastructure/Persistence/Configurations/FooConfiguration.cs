using Aljp.Domain.Entities;
using Aljp.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class FooConfiguration: IEntityTypeConfiguration<Foo>
{
    public void Configure(EntityTypeBuilder<Foo> builder)
    {
        builder.ToTable("Contracts", schema: "Common");
        builder.Property(p => p.Id).HasColumnName("ContractId");
        builder.Property(p => p.AwardDate).HasConversion<DateOnlyConverter>();
        builder.Property(p => p.ContractExpireDate).HasConversion<DateOnlyConverter>();
        builder.Property(p => p.IsoExpirationDate).HasConversion<DateOnlyConverter>();
        builder.Property(p => p.StartDate).HasConversion<DateOnlyConverter>();
    }
}