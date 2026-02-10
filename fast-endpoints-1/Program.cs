using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints(options =>
{
    options.Serializer.Options.PropertyNameCaseInsensitive = true;
    options.Serializer.Options.WriteIndented = true;
    options.Errors.UseProblemDetails();
});
app.Run();