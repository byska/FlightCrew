using FlightCrew.Application.Abstractions;
using FlightCrew.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightCrewDbContext _context;

        public UnitOfWork(FlightCrewDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
