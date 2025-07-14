using FlightCrew.Application.Abstractions;
using FlightCrew.Domain.Entities;
using FlightCrew.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Infrastructure.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly FlightCrewDbContext? _dbContext;

        public PilotRepository(FlightCrewDbContext? dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Pilot>> GetAllAsync(CancellationToken ct)
        {
            return await _dbContext.Pilots.Where(x=>x.IsActive).AsNoTracking().ToListAsync(ct);
        }

        public async Task<Pilot> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _dbContext.Pilots.Where(x=>x.Id==id && x.IsActive).FirstOrDefaultAsync(ct);
        }
    }
}
