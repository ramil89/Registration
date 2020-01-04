using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Domain.Countries;
using Registration.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.Customers
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(b => b.Id);
            builder.HasIndex(f => f.Login)
                .IsUnique();

            builder.Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(2048)
                .HasColumnName("Password")
                .IsRequired();

            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(f => f.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(f => f.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
