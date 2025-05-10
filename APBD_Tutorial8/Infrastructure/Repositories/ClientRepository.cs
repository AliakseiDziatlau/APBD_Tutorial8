using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DatabaseUtils;
using APBD_Tutorial8.Infrastructure.DTOs;
using APBD_Tutorial8.Infrastructure.Mappers;
using APBD_Tutorial8.Infrastructure.Repository;
using APBD_Tutorial8.Infrastructure.SqlCommands;
using APBD_Tutorial8.Infrastructure.SqlExtensions;

namespace APBD_Tutorial8.Infrastructure.Repositories;

public class ClientRepository : RepositoryBase, IClientRepository
{
    public ClientRepository(string connectionString) : base(connectionString) { }

    public async Task<IEnumerable<ClientsTripDto>> GetClientsTripsByIdAsync(int id)
    {
        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.GetClientsTripsById)
            .WithParameter("@ClientId", id)
            .ExecuteReaderAsync();
        
        return await DbUtils.MapListAsync(reader, SqlMapper.MapClientTrip);
    }

    public async Task<int> CreateClient(CreateClientCommand command)
    {
        var result = await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.CreateClient)
            .WithParameters(
                ("@FirstName", command.FirstName),
                ("@LastName", command.LastName),
                ("@Email", command.Email),
                ("@PhoneNumber", command.PhoneNumber),
                ("@Pesel", command.Pesel)
            )
            .ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.GetClientById)
            .WithParameter("@ClientId", id)
            .ExecuteReaderAsync();

        return await DbUtils.MapSingleAsync(reader, SqlMapper.MapClient);
    }

    public async Task RegisterClientToTrip(RegisterClientToTripDto registerClientToTripDto)
    {
        await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.RegisterClientToTrip)
            .WithParameters(
                ("@IdClient", registerClientToTripDto.IdClient),
                ("@IdTrip", registerClientToTripDto.IdTrip),
                ("@RegisteredAt", registerClientToTripDto.RegisteredAt)
            )
            .ExecuteNonQueryAsync();
    }

    public async Task DeleteClientForATrip(int clientId, int tripId)
    {
        await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.DeleteClientForATrip)
            .WithParameters(
                ("@IdClient", clientId),
                ("@IdTrip", tripId)
            )
            .ExecuteNonQueryAsync();
    }

    public async Task<RegisterClientToTripDto?> GetClientAndTrip(int clientId, int tripId)
    {
        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.GetClientAndTrip)
            .WithParameters(
                ("@IdClient", clientId),
                ("@IdTrip", tripId)
            )
            .ExecuteReaderAsync();

        return await DbUtils.MapSingleAsync(reader, SqlMapper.MapRegisterClientToTrip);
    }
}