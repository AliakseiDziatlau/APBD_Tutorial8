using APBD_Tutorial8.Infrastructure.Validators;
using FluentValidation.AspNetCore;

namespace APBD_Tutorial8.Application.Configurations;

public static class ValidationSettings
{
    public static IServiceCollection AddValidationSettings(this IServiceCollection services)
    {
        services.AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<ClientValidator>();
        });
        return services;
    }
}