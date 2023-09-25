using Rideshare_API.DTOs;
using Rideshare_API.Entities;

namespace Rideshare_API.Interfaces
{
    public interface IRiderRepository
    {
        public Task<RiderDTO?> GetRiderByIdAsync(string id);
    }
}
