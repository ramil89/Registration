using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Registration.Domain.Countries;
using Registration.Domain.Customers;
using Registration.Infrastructure.Countries;
using Registration.Infrastructure.Customers;

namespace Registration.Infrastructure
{
    public class CustomerContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Country> Countries { get; set; }

        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }
    }
}
