namespace APBD_Tutorial8.Infrastructure.SqlCommands;

public static class ClientSqlCommands
{
    public static string GetClientsTripsById =
        @"Select t.IdTrip as Id, t.Name, t.Description, t.DateFrom, t.DateTo, t.MaxPeople, ct.RegisteredAt, ct.PaymentDate
           from Client_Trip ct
           join Trip t on t.IdTrip = ct.IdTrip
           where ct.IdClient = @ClientId";

    public static string CreateClient =
        @"INSERT INTO Client (FirstName, LastName, Email, Telephone, Pesel)
        OUTPUT INSERTED.IdClient
        VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Pesel)";
    
    public static string GetClientById = 
        @"Select * from Client where IdClient = @ClientId";

    public static string RegisterClientToTrip = 
        @"Insert into Client_Trip (IdClient, IdTrip, RegisteredAt) values (@IdClient, @IdTrip, @RegisteredAt)";
    
    public static string GetClientAndTrip = 
        @"Select * from Client_Trip where IdClient = @IdClient and IdTrip = @IdTrip";
    
    public static string DeleteClientForATrip = 
        @"Delete from Client_Trip where IdClient = @IdClient and IdTrip = @IdTrip";
}