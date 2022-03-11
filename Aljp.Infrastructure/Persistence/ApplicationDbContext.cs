using System.Reflection;
using Aljp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aljp.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<MiniBid> MiniBids { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ProductLine> ProductLines { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<VendorProductLine>()
            .HasKey(bc => new { bc.VendorId, bc.ProductLineId });  
        builder.Entity<VendorProductLine>()
            .HasOne(bc => bc.Vendor)
            .WithMany(b => b.ProductLines)
            .HasForeignKey(bc => bc.VendorId);  
        // builder.Entity<VendorProductLine>()
        //     .HasOne(bc => bc.ProductLine)
        //     .WithMany(c => c.Vendors)
        //     .HasForeignKey(bc => bc.ProductLineId);
    }
}