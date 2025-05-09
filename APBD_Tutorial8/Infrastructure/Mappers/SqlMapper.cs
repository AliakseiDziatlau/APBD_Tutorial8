using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;
using Microsoft.Data.SqlClient;

namespace APBD_Tutorial8.Infrastructure.Mappers;

public static class SqlMapper
{
    public static ClientsTripDto MapClientTrip(SqlDataReader reader)
    {
        return new ClientsTripDto
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            Description = reader.GetString(reader.GetOrdinal("Description")),
            DateFrom = reader.GetDateTime(reader.GetOrdinal("DateFrom")),
            DateTo = reader.GetDateTime(reader.GetOrdinal("DateTo")),
            MaxPeople = reader.GetInt32(reader.GetOrdinal("MaxPeople")),
            RegisteredAt = reader.GetInt32(reader.GetOrdinal("RegisteredAt")),
            PaymentDate = reader.IsDBNull(reader.GetOrdinal("PaymentDate"))
                ? 0
                : reader.GetInt32(reader.GetOrdinal("PaymentDate"))
        };
    }
    
    public static Client MapClient(SqlDataReader reader)
    {
        return new Client
        {
            Id = reader.GetInt32(reader.GetOrdinal("IdClient")),
            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
            LastName = reader.GetString(reader.GetOrdinal("LastName")),
            Email = reader.GetString(reader.GetOrdinal("Email")),
            Phone = reader.GetString(reader.GetOrdinal("Telephone")),
            Pesel = reader.GetString(reader.GetOrdinal("Pesel"))
        };
    }
    
    public static RegisterClientToTripDto MapRegisterClientToTrip(SqlDataReader reader)
    {
        return new RegisterClientToTripDto
        {
            IdClient = reader.GetInt32(reader.GetOrdinal("IdClient")),
            IdTrip = reader.GetInt32(reader.GetOrdinal("IdTrip")),
            RegisteredAt = reader.GetInt32(reader.GetOrdinal("RegisteredAt"))
        };
    }
    
    public static CountryDto MapCountry(SqlDataReader reader)
    {
        return new CountryDto
        {
            Name = reader.GetString(reader.GetOrdinal("Name"))
        };
    }
    
    public static TripDto MapTrip(SqlDataReader reader)
    {
        return new TripDto
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            Description = reader.GetString(reader.GetOrdinal("Description")),
            DateFrom = reader.GetDateTime(reader.GetOrdinal("DateFrom")),
            DateTo = reader.GetDateTime(reader.GetOrdinal("DateTo")),
            MaxPeople = reader.GetInt32(reader.GetOrdinal("MaxPeople"))
        };
    }
    
    public static Trip MapTripEntity(SqlDataReader reader)
    {
        return new Trip
        {
            Id = reader.GetInt32(reader.GetOrdinal("IdTrip")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            Description = reader.GetString(reader.GetOrdinal("Description")),
            DateFrom = reader.GetDateTime(reader.GetOrdinal("DateFrom")),
            DateTo = reader.GetDateTime(reader.GetOrdinal("DateTo")),
            MaxPeople = reader.GetInt32(reader.GetOrdinal("MaxPeople"))
        };
    }
}