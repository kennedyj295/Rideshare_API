namespace Rideshare_API.Entities
{
    public class Driver : ApplicationUser
    {
        public string LicenseNumber { get; set; }
        public string VehicleType { get; set; }
        public List<DriverRating> DriverRatings { get; set; }
        public decimal AverageRating
        {
            get
            {
                if (DriverRatings == null || !DriverRatings.Any())
                {
                    return 0; 
                }
                return DriverRatings.Average(r => r.Value);
            }
        }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Ride> Rides { get; set; }
    }
}
