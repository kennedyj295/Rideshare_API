using Rideshare_API.Enums;

namespace Rideshare_API.Entities
{
    public class Ride
    {
        public int RideId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public RideStatus Status { get; set; }
        public decimal Fare {  get; set; }
        public DriverRating? DriverRating { get; set; }
        public RiderRating? RiderRating { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public int RiderId { get; set; }
        public virtual Rider Rider { get; set; }
    }
}
