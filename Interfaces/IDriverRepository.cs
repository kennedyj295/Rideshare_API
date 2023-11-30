using Rideshare_API.DTOs;

namespace Rideshare_API.Interfaces
{
    public interface IDriverRepository
    {
        public Task<DriverDTO?> GetDriverByIdAsync(string id);
    }
}
