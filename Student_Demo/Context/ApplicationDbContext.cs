using Microsoft.EntityFrameworkCore;
using Student_Demo.Models;
using System.Collections.Generic;

namespace Student_Demo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Departments)
                .WithOne(d => d.Location)
                .HasForeignKey(d => d.LocationId);
        }


    }
}
