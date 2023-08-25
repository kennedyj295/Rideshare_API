using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.Data;
using Rideshare_API.DTOs;
using Rideshare_API.Entities;
using Rideshare_API.Interfaces;

namespace Rideshare_API.Controllers
{
    
    public class RiderController : BaseApiController
    {
        private readonly IRiderRepository _riderRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public RiderController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IRiderRepository riderRepository, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _riderRepository = riderRepository;
            _mapper = mapper;
        }

        [HttpPost("registerrider")]
        public async Task<ActionResult<RiderDTO>> RegisterRider(RegisterDTO registerDTO)
        {
            if (await UserAlreadyExists(registerDTO.UserName)) return BadRequest("Username is already taken!");

            var user = _mapper.Map<Rider>(registerDTO);

            user.UserName = registerDTO.UserName.ToLower();

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Rider");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new RiderDTO
            {
                UserId = user.UserName,
                //Token = 
            };

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RiderDTO?>> GetUserById(int id)
        {
            return await _riderRepository.GetRiderByIdAsync(id);
        }

        private async Task<bool> UserAlreadyExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
