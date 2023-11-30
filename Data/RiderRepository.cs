using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.DTOs;
using Rideshare_API.Entities;
using Rideshare_API.Interfaces;
using AutoMapper;

namespace Rideshare_API.Data
{
    public class RiderRepository : IRiderRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RiderRepository (DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RiderDTO?> GetRiderByIdAsync(string id)
        {
            int.TryParse(id, out var converted);
            return await _context.Riders
                .Where(x => x.Id == converted)
                .ProjectTo<RiderDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
    }
}
