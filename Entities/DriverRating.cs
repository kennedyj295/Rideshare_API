namespace Rideshare_API.Entities
{
    public class DriverRating
    {
        public int DriverRatingId { get; set; }
        public decimal Value { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
