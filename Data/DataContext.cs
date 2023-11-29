using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.Entities;

namespace Rideshare_API.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CustomIdentityRole> CustomRoles { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CustomIdentityRole>().ToTable("Roles");
            builder.Entity<Driver>().ToTable("Drivers");
            builder.Entity<Rider>().ToTable("Riders");
        }
    }
}
