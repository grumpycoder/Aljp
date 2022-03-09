using Aljp.Domain.Entities;
using Aljp.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("Contracts", schema: "Common");
        builder.Property(p => p.Id).HasColumnName("ContractId");
        builder.Property(p => p.StateContractId).IsRequired(false);
        builder.Property(p => p.AwardDate).HasColumnType("datetime2").HasConversion<DateOnlyConverter>().IsRequired(false);
        builder.Property(p => p.StartDate).HasColumnType("datetime2").HasConversion<DateOnlyConverter>().IsRequired(false);
        builder.Property(p => p.ContractExpireDate).HasColumnType("datetime2").HasConversion<DateOnlyConverter>().IsRequired(false);;
        builder.Property(p => p.IsoExpirationDate)
            .HasColumnType("datetime2")
            .HasConversion<DateOnlyConverter>()
            .IsRequired(false);
        builder.Property(p => p.Discount).IsRequired(false);
        builder.Property(p => p.State470Number).IsRequired(false);
    }
}