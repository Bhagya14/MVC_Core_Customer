using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_Customer.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt) { }
        public DbSet<CustomerModel> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>().ToTable("tbl_customers");
            modelBuilder.Entity<CustomerModel>().HasKey(p => p.CustomerID);
            modelBuilder.Entity<CustomerModel>().Property(p => p.CustomerID).UseSqlServerIdentityColumn();
            modelBuilder.Entity<CustomerModel>().Property(p => p.CustomerName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CustomerModel>().Property(p => p.CustomerPassword).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CustomerModel>().Property(p => p.CustomerCity).IsRequired().HasMaxLength(100);

        }

    }
}
