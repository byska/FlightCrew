using FlightCrew.Domain.Entities;
using FlightCrew.Domain.Enums;
using FlightCrew.Domain.ValueObjects;
using FlightCrew.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Infrastructure.Seed
{
    public class SeedService
    {

        private readonly FlightCrewDbContext _context;

        public SeedService(FlightCrewDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Pilots.Any())
                return; 

            var pilot1 = new Pilot(
                Guid.NewGuid(),
                new PilotInfo(
                    name: "John Doe",
                    age: 45,
                    gender: GenderTypes.Male,
                    nationality: "USA",
                    knownLanguages: new List<Language>
                    {
                    new Language("en", "English"),
                    new Language("fr", "French")
                    }
                ),
                vehicleRestriction: AircraftType.Boeing737,
                allowedRange: new Domain.ValueObjects.Range(5000),
                seniorityLevel: SeniorityLevel.Senior
            );

            var pilot2 = new Pilot(
                Guid.NewGuid(),
                new PilotInfo(
                    name: "Jane Smith",
                    age: 32,
                    gender: GenderTypes.Female,
                    nationality: "UK",
                    knownLanguages: new List<Language>
                    {
                    new Language("en", "English"),
                    new Language("de", "German")
                    }
                ),
                vehicleRestriction: AircraftType.SukhoiSuperjet100,
                allowedRange: new Domain.ValueObjects.Range(3000),
                seniorityLevel: SeniorityLevel.Junior
            );

            var pilot3 = new Pilot(
                Guid.NewGuid(),
                new PilotInfo(
                    name: "Alice Brown",
                    age: 24,
                    gender: GenderTypes.Female,
                    nationality: "Canada",
                    knownLanguages: new List<Language>
                    {
                    new Language("en", "English"),
                    new Language("es", "Spanish")
                    }
                ),
                vehicleRestriction: AircraftType.Boeing737,
                allowedRange: new Domain.ValueObjects.Range(2000),
                seniorityLevel: SeniorityLevel.Trainee
            );

            _context.Pilots.AddRange(pilot1, pilot2, pilot3);
            _context.SaveChanges();

        }
    }
    }
