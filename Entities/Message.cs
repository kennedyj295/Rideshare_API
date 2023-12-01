namespace Rideshare_API.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int? SenderDriverId { get; set; }
        public int? SenderRiderId { get; set; }
        public int? ReceiverDriverId { get; set; }
        public int? ReceiverRiderId { get; set; }
        public virtual Driver? SenderDriver { get; set; }
        public virtual Rider? SenderRider { get; set; }
        public virtual Driver? ReceiverDriver { get; set; }
        public virtual Rider? ReceiverRider { get; set; }
    }
}
