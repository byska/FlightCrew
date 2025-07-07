using FlightCrew.Application.Abstractions;
using FlightCrew.Domain.Enums;
using FlightCrew.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCrew.Application.UseCases.PilotUseCases.Queries
{
    public class GetAllFlightsQueryRequest : IRequest<List<GetAllPilotsQueryResponse>>
    {

    }
    public class GetAllPilotsQueryResponse
    {
        public PilotInfoResponse Info { get;  set; }
        public string VehicleRestriction { get;  set; }
        public double AllowedRange { get;  set; }
        public string SeniorityLevel { get;  set; }

    }
    public class PilotInfoResponse
    {
        public string Name { get;  set; }
        public int Age { get;  set; }
        public string Gender { get;  set; }
        public string Nationality { get;  set; }
        public List<string> KnownLanguages { get; set; }
    }
    public class GetAllPilotsQueryHandler : IRequestHandler<GetAllFlightsQueryRequest, List<GetAllPilotsQueryResponse>>
    {
        private readonly IPilotRepository _repo;

        public GetAllPilotsQueryHandler(IPilotRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<GetAllPilotsQueryResponse>> Handle(GetAllFlightsQueryRequest request, CancellationToken cancellationToken)
        {
            var pilots = await _repo.GetAllAsync(cancellationToken);

            var response = pilots.Select(p => new GetAllPilotsQueryResponse
            {
                Info = new PilotInfoResponse
                {
                    Name = p.Info.Name,
                    Age = p.Info.Age,
                    Gender = p.Info.Gender.ToString(),
                    Nationality = p.Info.Nationality,
                    KnownLanguages = p.Info.KnownLanguages.Select(l => l.Name).ToList()
                },
                VehicleRestriction = p.VehicleRestriction.ToString(),
                AllowedRange = p.AllowedRange.Distance,
                SeniorityLevel = p.SeniorityLevel.ToString()
            }).ToList();

            return response;
        }
    }
}
