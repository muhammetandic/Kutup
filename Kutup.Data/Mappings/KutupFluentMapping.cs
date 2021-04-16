using Kutup.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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

    public class DataImportMap : IEntityTypeConfiguration<DataImport>
    {
        public void Configure(EntityTypeBuilder<DataImport> builder)
        {
            builder.Property(p => p.Nodes)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, default),
                    v => JsonSerializer.Deserialize<IList<string>>(v, default),
                    new ValueComparer<IList<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
        }
    }

    public class DataImportHistoryMap : IEntityTypeConfiguration<DataImportHistory>
    {
        public void Configure(EntityTypeBuilder<DataImportHistory> builder)
        {
            builder.Property(p => p.ErrorLogs)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, default),
                    v => JsonSerializer.Deserialize<IDictionary<int, string>>(v, default),
                    new ValueComparer<IDictionary<int, string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (IDictionary<int, string>)c.ToList()));
        }
    }
}
