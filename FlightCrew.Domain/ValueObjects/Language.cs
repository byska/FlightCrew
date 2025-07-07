using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Domain.ValueObjects
{
    public class Language
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        private Language() { } // EF için

        public Language(string code, string name)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is required");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");

            Code = code;
            Name = name;
        }
    }
}
