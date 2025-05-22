using ContactSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Dal.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(256); 

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(u => u.Salt)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasOne(u => u.UserRole)
            .WithMany(ur => ur.Users)
            .HasForeignKey(u => u.UserRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
