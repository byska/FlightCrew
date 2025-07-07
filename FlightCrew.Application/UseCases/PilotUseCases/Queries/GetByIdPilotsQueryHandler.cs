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
    public class GetByIdFlightsQueryRequest : IRequest<GetByIdPilotsQueryResponse>
    {
        public Guid Id { get; set; }
        public GetByIdFlightsQueryRequest(Guid ıd)
        {
            Id = ıd;
        }
    }
    public class GetByIdPilotsQueryResponse
    {
        public PilotInfoResponse Info { get; set; }
        public string VehicleRestriction { get; set; }
        public double AllowedRange { get; set; }
        public string SeniorityLevel { get; set; }

    }
   
    public class GetByIdPilotsQueryHandler : IRequestHandler<GetByIdFlightsQueryRequest, GetByIdPilotsQueryResponse>
    {
        private readonly IPilotRepository _repo;

        public GetByIdPilotsQueryHandler(IPilotRepository repo)
        {
            _repo = repo;
        }
        public async Task<GetByIdPilotsQueryResponse> Handle(GetByIdFlightsQueryRequest request, CancellationToken cancellationToken)
        {
            var pilot = await _repo.GetByIdAsync(request.Id,cancellationToken);
            if (pilot is null) return null;

            var response = new GetByIdPilotsQueryResponse
            {
                Info = new PilotInfoResponse
                {
                    Name = pilot.Info.Name,
                    Age = pilot.Info.Age,
                    Gender = pilot.Info.Gender.ToString(),
                    Nationality = pilot.Info.Nationality,
                    KnownLanguages = pilot.Info.KnownLanguages.Select(l => l.Name).ToList()
                },
                VehicleRestriction = pilot.VehicleRestriction.ToString(),
                AllowedRange = pilot.AllowedRange.Distance,
                SeniorityLevel = pilot.SeniorityLevel.ToString()
            };

            return response;
        }
    }
}
