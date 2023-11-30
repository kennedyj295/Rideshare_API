using Rideshare_API.Entities;

namespace Rideshare_API.Data
{
    public class DataSeeder
    {
        private readonly DataContext _context;

        public DataSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            await SeedDriversAsync();
            await SeedRidersAsync();
        }

        private async Task SeedDriversAsync()
        {
            if (!_context.Drivers.Any())
            {
                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var driver = new Driver
                    {
                        UserName = "driveruser" + random.Next(1000, 9999),
                        Email = "driver" + random.Next(1000, 9999) + "@example.com",
                        FirstName = "DriverFirstName" + random.Next(1, 100),
                        LastName = "DriverLastName" + random.Next(1, 100),
                        Address = "DriverAddress" + random.Next(1, 100),
                        LicenseNumber = "LIC" + random.Next(1000, 9999),
                        VehicleType = "Sedan",
                        rating = (decimal)(random.NextDouble() * 5.0)
                    };

                    _context.Drivers.Add(driver);
                }
                await _context.SaveChangesAsync();
            }
        }


        private async Task SeedRidersAsync()
        {
            if (!_context.Riders.Any())
            {
                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var rider = new Rider
                    {
                        UserName = "rideruser" + random.Next(1000, 9999),
                        Email = "rider" + random.Next(1000, 9999) + "@example.com",
                        FirstName = "RiderFirstName" + random.Next(1, 100),
                        LastName = "RiderLastName" + random.Next(1, 100),
                        Address = "RiderAddress" + random.Next(1, 100),
                        Rating = (decimal)(random.NextDouble() * 5.0)
                    };

                    _context.Riders.Add(rider);
                }
                await _context.SaveChangesAsync();
            }
        }


    }
}
