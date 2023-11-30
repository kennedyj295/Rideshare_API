using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.Data;
using Rideshare_API.DTOs;
using Rideshare_API.Entities;
using Rideshare_API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Rideshare_API.Interfaces;

namespace Rideshare_API.Controllers
{
    public class DriverController : BaseApiController
    {
        private readonly IDriverRepository _driverRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public DriverController (UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, 
            IDriverRepository driverRepository, IMapper mapper, TokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _driverRepository = driverRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("registerdriver")]
        public async Task<ActionResult<DriverDTO>> RegisterDriver (RegisterDTO registerDTO)
        {
            if (await UserAlreadyExists(registerDTO.UserName)) return BadRequest("Username is already taken!");

            var user = _mapper.Map<Driver>(registerDTO);

            user.UserName = registerDTO.UserName.ToLower();

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Driver");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new DriverDTO
            {
                UserId = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = await _tokenService.GenerateTokenAsync(registerDTO.UserName, registerDTO.Password)
            };

        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<DriverDTO?>> GetUserById(string id)
        {
            return await _driverRepository.GetDriverByIdAsync(id);
        }

        private async Task<bool> UserAlreadyExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
