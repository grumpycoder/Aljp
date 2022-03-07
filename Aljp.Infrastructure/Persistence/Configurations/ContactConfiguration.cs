using Aljp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aljp.Infrastructure.Persistence.Configurations;

public class ContactConfiguration: IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts", schema: "Common");
        builder.Property(p => p.Id).HasColumnName("ContactId");
        builder.Property(p => p.MobilePhone).IsRequired(false);
        builder.Property(p => p.BusinessPhone).IsRequired(false);
    }
}