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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}