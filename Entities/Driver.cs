namespace Rideshare_API.Entities
{
    public class Driver : ApplicationUser
    {
        public string LicenseNumber { get; set; }
        public string VehicleType { get; set; }
    }
}
