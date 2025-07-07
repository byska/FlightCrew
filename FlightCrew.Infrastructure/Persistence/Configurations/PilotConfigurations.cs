using FlightCrew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Infrastructure.Persistence.Configurations
{
    public class PilotConfigurations : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Info, info =>
            {
                info.Property(i => i.Name).IsRequired().HasMaxLength(100);
                info.Property(i => i.Age).IsRequired();
                info.Property(i => i.Gender).IsRequired();
                info.Property(i => i.Nationality).IsRequired().HasMaxLength(50);

                info.OwnsMany(i => i.KnownLanguages, lang =>
                {
                    lang.WithOwner();
                    lang.Property(l => l.Code).IsRequired().HasMaxLength(5);
                    lang.Property(l => l.Name).IsRequired().HasMaxLength(50);
                    lang.ToTable("PilotLanguages");
                });
            });

            builder.OwnsOne(p => p.AllowedRange, range =>
            {
                range.Property(r => r.Distance).IsRequired();
            });

            builder.Property(p => p.VehicleRestriction)
                .IsRequired();

            builder.Property(p => p.SeniorityLevel)
                .IsRequired();

            builder.ToTable("Pilots");
        }
    }
}
