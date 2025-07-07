using FlightCrew.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Domain.ValueObjects
{
    public class PilotInfo
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public GenderTypes Gender { get; private set; }
        public string Nationality { get; private set; }
        public IReadOnlyCollection<Language> KnownLanguages => _knownLanguages.AsReadOnly();

        private readonly List<Language> _knownLanguages = new();

        private PilotInfo() { } 

        public PilotInfo(string name, int age, GenderTypes gender, string nationality, IEnumerable<Language> knownLanguages)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
            if (age <= 0) throw new ArgumentException("Age must be positive");
            if (string.IsNullOrWhiteSpace(nationality)) throw new ArgumentException("Nationality is required");

            Name = name;
            Age = age;
            Gender = gender;
            Nationality = nationality;
            _knownLanguages = knownLanguages?.ToList() ?? throw new ArgumentNullException(nameof(knownLanguages));
        }
    }
}
