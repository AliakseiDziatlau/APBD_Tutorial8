namespace APBD_Tutorial8.Infrastructure.SqlCommands;

public static class CountrySqlCommands
{
    public static string GetCountriesForTrip = @"Select c.Name 
            from Country c
            join Country_Trip ct on ct.IdCountry = c.IdCountry
            where ct.IdTrip = @IdTrip";
}
