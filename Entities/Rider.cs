namespace Rideshare_API.Entities
{
    public class Rider : ApplicationUser
    {
        public List<RiderRating> RiderRatings { get; set; }

        public decimal AverageRating
        {
            get
            {
                if (RiderRatings == null || !RiderRatings.Any())
                {
                    return 0;
                }
                return RiderRatings.Average(r => r.Value);
            }
        }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Ride> Rides { get; set; }
    }
}
