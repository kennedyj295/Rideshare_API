using Microsoft.AspNetCore.Mvc;
using Rideshare_API.DTOs;
using Rideshare_API.Interfaces;

namespace Rideshare_API.Controllers
{
    public class RiderController : BaseApiController
    {
        private readonly IRiderRepository _riderRepository;
        public RiderController(IRiderRepository riderRepository)
        {
            _riderRepository = riderRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RiderDTO?>> GetUserById(int id)
        {
            return await _riderRepository.GetRiderByIdAsync(id);
        }
    }
}
