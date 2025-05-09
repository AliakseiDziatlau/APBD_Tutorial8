using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Infrastructure.DTOs;
using MediatR;

namespace APBD_Tutorial8.Application.Handlers.ClientHandlers;

public class RegisterClientForATripCommandHandler : HandlerBase, IRequestHandler<RegisterClientForATripCommand, (bool Success, string Message)>
{
    public RegisterClientForATripCommandHandler(IClientRepository clientRepository, ITripRepository tripRepository, ICountryRepository countryRepository) : base(clientRepository, tripRepository, countryRepository) { }

    public async Task<(bool Success, string Message)> Handle(RegisterClientForATripCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
        if (client is null)
            return (false, $"Client with ID {request.ClientId} not found.");

        var trip = await _tripRepository.GetTripByIdAsync(request.TripId);
        if (trip is null)
            return (false, $"Trip with ID {request.TripId} not found.");

        var clientTrip = new RegisterClientToTripDto
        {
            IdClient = request.ClientId,
            IdTrip = request.TripId,
            RegisteredAt = int.Parse(DateTime.Now.ToString("yyyyMMdd"))
        };

        try
        {
            await _clientRepository.RegisterClientToTrip(clientTrip);
            return (true, "Client successfully registered for the trip.");
        }
        catch (Exception ex)
        {
            return (false, "An unexpected error occurred while registering the client.");
        }
    }
}