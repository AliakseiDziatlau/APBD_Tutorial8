using APBD_Tutorial8.Application.Queries.ClientQueries;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;
using MediatR;

namespace APBD_Tutorial8.Application.Handlers.ClientHandlers;

public class GetClietnsTripsByIdQueryHandler : HandlerBase, IRequestHandler<GetClientsTripsByIdQuery, IEnumerable<ClientsTripDto>>
{
    public GetClietnsTripsByIdQueryHandler(IClientRepository clientRepository, ITripRepository tripRepository, ICountryRepository countryRepository) : base(clientRepository, tripRepository, countryRepository) { }

    public async Task<IEnumerable<ClientsTripDto>> Handle(GetClientsTripsByIdQuery request, CancellationToken cancellationToken)
    {
        return  await _clientRepository.GetClientsTripsByIdAsync(request.ClientId);
    }
}