namespace APBD_Tutorial8.Infrastructure.SqlCommands;

public static class TripSqlCommands
{
    public const string GetAllTrips =
        @"SELECT 
        t.IdTrip as Id, t.Name, t.Description, t.DateFrom, t.DateTo, t.MaxPeople
        FROM Trip t";
    
    public static string GetTripById = 
        @"Select * from Trip where IdTrip = @TripId";
}