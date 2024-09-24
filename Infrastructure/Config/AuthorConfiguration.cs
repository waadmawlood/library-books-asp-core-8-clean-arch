using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Biography).IsRequired().HasMaxLength(2000);
        builder.Property(a => a.BirthDate).IsRequired();
        builder.Property(a => a.Nationality).IsRequired().HasMaxLength(50);
        builder.Property(a => a.Gender).IsRequired().HasMaxLength(10);
    }
}
