using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Domain.Interfaces;

public interface ITripRepository
{
    Task<IEnumerable<TripDto>> GetTripsAsync();
    Task<Trip?> GetTripByIdAsync(int id);
}