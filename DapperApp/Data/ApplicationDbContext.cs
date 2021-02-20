using DapperApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // think this like the NotMapped property, tells ef to not add to db
            builder.Entity<Company>().Ignore(c => c.Employees);

            
            builder.Entity<Employee>()
                .HasOne(c => c.Company).WithMany(a => a.Employees).HasForeignKey(x => x.CompanyId);
        }
    }
}
