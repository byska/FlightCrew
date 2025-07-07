using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Domain.ValueObjects
{
    public class Range
    {
        public double Distance { get; private set; } 

        private Range() { } 

        public Range(double distance)
        {
            if (distance <= 0) throw new ArgumentException("Distance must be positive");
            Distance = distance;
        }

        public bool IsWithin(double target) => target <= Distance;
    }
}
