using APBD_Tutorial8.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureServices()
    .AddValidationSettings()
    .AddApplicationSettings(builder.Configuration);

var app = builder.Build();

app.AddSwaggerSettings().MapControllers();
app.Run();

