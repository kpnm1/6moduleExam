using ContactSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Dal.EntityConfiguration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("userRoles");

        builder.HasKey(ur => ur.UserRoleId);

        builder.Property(ur => ur.Role)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ur => ur.RoleDefinition)
            .HasMaxLength(200);
    }
}
