using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Domain.Interfaces;
using MediatR;

namespace APBD_Tutorial8.Application.Handlers.ClientHandlers;

public class DeleteClientForATripCommandHandler : HandlerBase,  IRequestHandler<DeleteClientForATripCommand, (bool Success, string Message)>
{
    public DeleteClientForATripCommandHandler(IClientRepository clientRepository, ITripRepository tripRepository, ICountryRepository countryRepository) : base(clientRepository, tripRepository, countryRepository) { }

    public async Task<(bool Success, string Message)> Handle(DeleteClientForATripCommand request, CancellationToken cancellationToken)
    {
        var registration = await _clientRepository.GetClientAndTrip(request.ClientId, request.TripId);
        if (registration is null)
            return (false, $"No registration found for Client ID {request.ClientId} and Trip ID {request.TripId}.");

        try
        {
            await _clientRepository.DeleteClientForATrip(request.ClientId, request.TripId);
            return (true, "Client successfully unregistered from the trip.");
        }
        catch (Exception ex)
        {
            return (false, "An error occurred while unregistering the client.");
        }
    }
}