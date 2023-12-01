namespace Rideshare_API.Entities
{
    public class RiderRating
    {
        public int RiderRatingId { get; set; }
        public decimal Value { get; set; }
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
    }
}
