using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DatabaseUtils;
using APBD_Tutorial8.Infrastructure.DTOs;
using APBD_Tutorial8.Infrastructure.Mappers;
using APBD_Tutorial8.Infrastructure.Repository;
using APBD_Tutorial8.Infrastructure.SqlCommands;
using APBD_Tutorial8.Infrastructure.SqlExtensions;

namespace APBD_Tutorial8.Infrastructure.Repositories;

public class TripRepository : RepositoryBase, ITripRepository
{
    public TripRepository(string connectionString) : base(connectionString) { }

    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(TripSqlCommands.GetAllTrips)
            .ExecuteReaderAsync();

        return await DbUtils.MapListAsync(reader, SqlMapper.MapTrip);
    }

    public async Task<Trip?> GetTripByIdAsync(int id)
    {
        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(TripSqlCommands.GetTripById)
            .WithParameter("@TripId", id)
            .ExecuteReaderAsync();

        return await DbUtils.MapSingleAsync(reader, SqlMapper.MapTripEntity);
    }
}