
using FluentValidation;
using Granito.Calculo.Api;
using Granito.Calculo.Api.Application.Calculos.Commands;
using Granito.Calculo.Api.Services.RequestProvider;
using Granito.Calculo.Api.Validations;
using MediatR;
using System.Reflection;

public class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddProblemDetails(options =>
                options.CustomizeProblemDetails = (context) =>
                {
                    var mathErrorFeature = context.HttpContext.Features.Get<ValidationException>();

                    if (mathErrorFeature != null)
                    {
                        context.ProblemDetails.Type = mathErrorFeature.HelpLink;
                        context.ProblemDetails.Title = "Falha na validação.";
                        context.ProblemDetails.Detail = mathErrorFeature.Message;
                        context.ProblemDetails.Extensions.Add("Erros", mathErrorFeature.Errors.Select(s => new { s.PropertyName, s.ErrorMessage }));
                    }
                }
            );

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        builder.Services.AddSingleton<IRequestProvider, RequestProvider>();

        builder.Services.AddSingleton(new ApiSettings
        {
            TaxaApiUrl = builder.Configuration.GetValue<string>("TaxasApiUrl") ?? string.Empty,
        });

        builder.Services.AddScoped<IValidator<CalcularJurosCompostoCommand>, CalcularJurosCompostoCommandValidation>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}

        app.UseExceptionHandler();

        app.UseStatusCodePages();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}