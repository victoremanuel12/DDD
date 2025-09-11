using Scalar.AspNetCore;
using Wpm.Infra.IoC;
using Wpm.Management.Api.EndpointsExtension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapAllEndpoints();
app.EnsureDatabaseIsCreated();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();

app.Run();
