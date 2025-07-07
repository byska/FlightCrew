using FlightCrew.Domain.Enums;
using FlightCrew.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Domain.Entities
{
    public class Pilot
    {
        public Guid Id { get; private set; }

        public PilotInfo Info { get; private set; }
        public AircraftType VehicleRestriction { get; private set; }
        public Domain.ValueObjects.Range AllowedRange { get; private set; }
        public SeniorityLevel SeniorityLevel { get; private set; }

        private Pilot() { } 

        public Pilot(Guid id, PilotInfo info,  AircraftType vehicleRestriction, Domain.ValueObjects.Range allowedRange, SeniorityLevel seniorityLevel)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Info = info ?? throw new ArgumentNullException(nameof(info));
            VehicleRestriction = vehicleRestriction;
            AllowedRange = allowedRange ?? throw new ArgumentNullException(nameof(allowedRange));
            SeniorityLevel = seniorityLevel;
        }
        public bool CanOperateVehicle(AircraftType type) => VehicleRestriction == type;

        public bool IsWithinAllowedRange(double distance) => AllowedRange.IsWithin(distance);

        public bool IsSenior() => SeniorityLevel == SeniorityLevel.Senior;
        public bool IsJunior() => SeniorityLevel == SeniorityLevel.Junior;
        public bool IsTrainee() => SeniorityLevel == SeniorityLevel.Trainee;

    }
}
