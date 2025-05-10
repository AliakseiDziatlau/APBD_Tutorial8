using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Infrastructure.DatabaseUtils;
using APBD_Tutorial8.Infrastructure.DTOs;
using APBD_Tutorial8.Infrastructure.Mappers;
using APBD_Tutorial8.Infrastructure.SqlCommands;
using APBD_Tutorial8.Infrastructure.SqlExtensions;

namespace APBD_Tutorial8.Infrastructure.Repository;

public class CountryRepository : RepositoryBase, ICountryRepository
{
    public CountryRepository(string connectionString) : base(connectionString) { }

    public async Task<IEnumerable<CountryDto>> GetCountriesForTripAsync(int tripId)
    {
        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(CountrySqlCommands.GetCountriesForTrip)
            .WithParameter("@IdTrip", tripId)
            .ExecuteReaderAsync();
        
        return await DbUtils.MapListAsync(reader, SqlMapper.MapCountry);
    }
}