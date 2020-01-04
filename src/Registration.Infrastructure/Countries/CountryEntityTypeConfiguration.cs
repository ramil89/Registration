using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.Countries
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(k => k.Id);

            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(f => f.ParentId);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
                new Country("Country 1", 1),
                new Country("Country 2", 2),
                new Country("Country 3", 3),

                new Country("Province 1.1", 4, 1),
                new Country("Province 1.2", 5, 1),

                new Country("Province 2.1", 6, 2),
                new Country("Province 2.2", 7, 2),

                new Country("Province 3.1", 8, 3),
                new Country("Province 3.2", 9, 3)
                );
        }
    }
}
