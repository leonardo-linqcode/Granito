using Granito.Calculo.Api;
using Granito.Calculo.Api.Services.RequestProvider;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<IRequestProvider, RequestProvider>();

builder.Services.AddSingleton(new ApiSettings 
{
    TaxaApiUrl = builder.Configuration.GetValue<string>("TaxasApiUrl") ?? string.Empty,
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
