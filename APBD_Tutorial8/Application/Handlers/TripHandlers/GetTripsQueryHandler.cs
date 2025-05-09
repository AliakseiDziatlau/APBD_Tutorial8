using APBD_Tutorial8.Application.Queries.TripQueries;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Infrastructure.DTOs;
using MediatR;

namespace APBD_Tutorial8.Application.Handlers.TripHandlers;

public class GetTripsQueryHandler : HandlerBase, IRequestHandler<GetTripsQuery, IEnumerable<TripDto>>
{
    public GetTripsQueryHandler(IClientRepository clientRepository, ITripRepository tripRepository, ICountryRepository countryRepository) : base(clientRepository, tripRepository, countryRepository) { }

    public async Task<IEnumerable<TripDto>> Handle(GetTripsQuery request, CancellationToken cancellationToken)
    {
        var trips = await _tripRepository.GetTripsAsync();

        var enrichedTrips = await Task.WhenAll(trips.Select(async trip =>
        {
            trip.Countries = (await _countryRepository.GetCountriesForTripAsync(trip.Id)).ToList();
            return trip;
        }));

        return enrichedTrips;
    }
}