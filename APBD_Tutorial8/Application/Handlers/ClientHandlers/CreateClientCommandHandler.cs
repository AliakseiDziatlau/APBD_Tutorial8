using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Domain.Interfaces;
using MediatR;

namespace APBD_Tutorial8.Application.Handlers.ClientHandlers;

public class CreateClientCommandHandler : HandlerBase, IRequestHandler<CreateClientCommand, int>
{
    public CreateClientCommandHandler(IClientRepository clientRepository, ITripRepository tripRepository, ICountryRepository countryRepository) : base(clientRepository, tripRepository, countryRepository) { }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        return await _clientRepository.CreateClient(request);
    }
}