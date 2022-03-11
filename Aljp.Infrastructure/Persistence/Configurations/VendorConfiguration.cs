using Aljp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class VendorConfiguration: IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable("Vendors", schema: "Common");
        builder.Property(p => p.Id).HasColumnName("VendorId");

        // builder.HasMany(p => p.ProductLines).WithMany("Vendors"); 
        
        // builder.HasMany(x => x.ProductLines)
        //     .WithMany("Vendors")
        //     .UsingEntity<VendorProductLine>(
        //     e => e.HasOne(x => x.ProductLine).WithMany(),
        //     e => e.HasOne(x => x.Vendor).WithMany(),
        //     join =>
        //     {
        //         join.ToTable("VendorProductLines", "Common");
        //         join.HasKey(line => new { line.VendorId, line.ProductLineId });
        //     });
        
        // builder.Navigation(v => v.Contacts).AutoInclude(); 
    }
}