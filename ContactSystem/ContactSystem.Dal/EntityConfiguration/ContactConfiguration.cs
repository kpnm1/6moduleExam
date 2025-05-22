using ContactSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Dal.EntityConfiguration;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("contacts");

        builder.HasKey(c => c.ContactId);

        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.UserName)
            .HasMaxLength(101);

        builder.Property(c => c.Email)
            .HasMaxLength(100);

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(c => c.Address)
            .HasMaxLength(200);

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.HasOne(c => c.User)
            .WithMany(u => u.Contacts)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
