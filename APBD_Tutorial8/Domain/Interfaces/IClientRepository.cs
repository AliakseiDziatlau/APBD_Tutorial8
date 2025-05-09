using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Domain.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<ClientsTripDto>> GetClientsTripsByIdAsync(int id);
    Task<int> CreateClient(CreateClientCommand createClientCommand);
    Task<Client?> GetClientByIdAsync(int id);
    Task RegisterClientToTrip(RegisterClientToTripDto registerClientToTripDto);
    Task DeleteClientForATrip(int clientId, int tripId);
    Task<RegisterClientToTripDto?> GetClientAndTrip(int clientId, int tripId);
}