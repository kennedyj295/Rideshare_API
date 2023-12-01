using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.Entities;

namespace Rideshare_API.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<IdentityRole> CustomRoles { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverRating> DriverRatings { get; set; }
        public DbSet<RiderRating> RiderRatings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().ToTable("Roles");
            
            builder.Entity<Driver>()
                .ToTable("Drivers")
                .HasMany(d => d.DriverRatings)
                .WithOne(r => r.Driver)
                .HasForeignKey(r => r.DriverId);
            
            builder.Entity<Rider>()
                .ToTable("Riders")
                .HasMany(x => x.RiderRatings)
                .WithOne(r => r.Rider)
                .HasForeignKey(r => r.RiderId);
            
            builder.Entity<Message>()
                .HasOne(m => m.SenderDriver)
                .WithMany(d => d.SentMessages)
                .HasForeignKey(m => m.SenderDriverId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Message>()
                .HasOne(m => m.ReceiverDriver)
                .WithMany(d => d.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverDriverId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Message>()
                .HasOne(m => m.SenderRider)
                .WithMany(r => r.SentMessages)
                .HasForeignKey(m => m.SenderRiderId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Message>()
                .HasOne(m => m.ReceiverRider)
                .WithMany(r => r.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverRiderId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ride>()
                .HasOne(r => r.Rider)
                .WithMany(p => p.Rides)
                .HasForeignKey(r => r.RiderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
