namespace APBD_Tutorial8.Application.Configurations;

public static class SwaggerSettings
{
    public static WebApplication AddSwaggerSettings(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }
}