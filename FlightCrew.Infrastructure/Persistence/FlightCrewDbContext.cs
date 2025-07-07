using FlightCrew.Application.Abstractions;
using FlightCrew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Infrastructure.Persistence
{
    public class FlightCrewDbContext : DbContext, IUnitOfWork
    {
        public FlightCrewDbContext(DbContextOptions<FlightCrewDbContext> options) : base(options)
        {
        }
        public DbSet<Pilot> Pilots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Configurations.PilotConfigurations());
        }
    }
}
