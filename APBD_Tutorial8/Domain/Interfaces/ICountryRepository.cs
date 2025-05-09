using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Domain.Interfaces;

public interface ICountryRepository
{
    Task<IEnumerable<CountryDto>> GetCountriesForTripAsync(int tripId);
}