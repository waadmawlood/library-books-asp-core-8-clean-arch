using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(a => a.Title).IsRequired().HasMaxLength(150);
        builder.Property(a => a.Description).IsRequired().HasMaxLength(2000);
        builder.Property(a => a.PublicationDate).IsRequired().HasColumnType("date");
        builder.Property(a => a.Language).IsRequired().HasMaxLength(50);
        builder.Property(a => a.ISBN).IsRequired().HasMaxLength(13);
        builder.Property(a => a.Publisher).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Filename).IsRequired(false).HasMaxLength(1000);
        builder.Property(a => a.Image).IsRequired(false).HasMaxLength(1000);
    }
}
