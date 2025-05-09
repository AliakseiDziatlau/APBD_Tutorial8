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
        //var trips = new List<ClientsTripDto>();

        await using var reader = await FluentSql
            .From(_connectionString)
            .WithSql(ClientSqlCommands.GetClientsTripsById)
            .WithParameter("@ClientId", id)
            .ExecuteReaderAsync();
        
        return await DbUtils.MapListAsync(reader, SqlMapper.MapClientTrip);

        // while (await reader.ReadAsync())
        // {
        //     trips.Add(new ClientsTripDto
        //     {
        //         Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //         Name = reader.GetString(reader.GetOrdinal("Name")),
        //         Description = reader.GetString(reader.GetOrdinal("Description")),
        //         DateFrom = reader.GetDateTime(reader.GetOrdinal("DateFrom")),
        //         DateTo = reader.GetDateTime(reader.GetOrdinal("DateTo")),
        //         MaxPeople = reader.GetInt32(reader.GetOrdinal("MaxPeople")),
        //         RegisteredAt = reader.GetInt32(reader.GetOrdinal("RegisteredAt")),
        //         PaymentDate = reader.IsDBNull(reader.GetOrdinal("PaymentDate"))
        //             ? 0
        //             : reader.GetInt32(reader.GetOrdinal("PaymentDate"))
        //     });
        // }

        //return trips;
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
        
        // if (await reader.ReadAsync())
        // {
        //     return new Client
        //     {
        //         Id = reader.GetInt32(reader.GetOrdinal("IdClient")),
        //         FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
        //         LastName = reader.GetString(reader.GetOrdinal("LastName")),
        //         Email = reader.GetString(reader.GetOrdinal("Email")),
        //         Phone = reader.GetString(reader.GetOrdinal("Telephone")),
        //         Pesel = reader.GetString(reader.GetOrdinal("Pesel")),
        //     };
        // }
        //
        // return null;
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
        
        // if (await reader.ReadAsync())
        // {
        //     return new RegisterClientToTripDto
        //     {
        //         IdClient = reader.GetInt32(reader.GetOrdinal("IdClient")),
        //         IdTrip = reader.GetInt32(reader.GetOrdinal("IdTrip")),
        //         RegisteredAt = reader.GetInt32(reader.GetOrdinal("RegisteredAt"))
        //     };
        // }
        //
        // return null;
    }
}