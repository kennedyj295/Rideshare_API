using Rideshare_API.Entities;
using System;

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
            await SeedMessagesAsync();
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
                    };

                    _context.Drivers.Add(driver);

                    for (int j = 0; j < 5; j++) 
                    {
                        var rating = new DriverRating
                        {
                            Value = random.Next(1, 6), // Random rating between 1 and 5
                            Driver = driver
                        };

                        _context.DriverRatings.Add(rating);
                    }

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
                    };

                    _context.Riders.Add(rider);


                    for (int j = 0; j < 5; j++)
                    {
                        var rating = new RiderRating
                        {
                            Value = random.Next(1, 6),
                            Rider = rider
                        };

                        _context.RiderRatings.Add(rating);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedMessagesAsync()
        {
            if (!_context.Messages.Any())
            {
                var random = new Random();
                var drivers = _context.Drivers.ToList();
                var riders = _context.Riders.ToList();

                for (int i = 0; i < 20; i++) 
                {
                    var senderDriver = drivers[random.Next(drivers.Count)];
                    var receiverRider = riders[random.Next(riders.Count)];

                    var message = new Message
                    {
                        Content = "Sample message content " + i,
                        Timestamp = DateTime.UtcNow,
                        SenderDriver = senderDriver,
                        ReceiverRider = receiverRider
                    };

                    _context.Messages.Add(message);
                }

                await _context.SaveChangesAsync();
            }
        }


    }
}
