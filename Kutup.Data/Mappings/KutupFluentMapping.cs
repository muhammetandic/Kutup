using Kutup.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kutup.Data.Mappings
{
    public class KutupFluentMapping
    {
    }

    public class CatergoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }

    public class AuthorMap :IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }

    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Publisher)
                .HasMaxLength(100);
            builder.Property(x => x.CoverImage)
                .HasMaxLength(255);
            builder.HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.AuthorId);
            builder.HasOne(c => c.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}
