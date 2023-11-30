using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.DTOs;
using Rideshare_API.Entities;
using Rideshare_API.Interfaces;
using AutoMapper;

namespace Rideshare_API.Data
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DriverRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DriverDTO?> GetDriverByIdAsync(string id)
        {
            int.TryParse(id, out var converted);
            return await _context.Drivers
                .Where(x => x.Id == converted)
                .ProjectTo<DriverDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
    }
}
