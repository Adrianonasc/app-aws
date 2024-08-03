using empresaApi.Apis;
using empresaApi.Infra;
using empresaApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace empresaApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateSlimBuilder(args);

			builder.Services.ConfigureHttpJsonOptions(options =>
			{
				options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
			});

			var services = builder.Services;

			services.AddSingleton<IConfiguration>(provider => builder.Configuration);

			services.AddHealthChecks()
					.AddDbContextCheck<Infra.EmpresaContext>();

			services.AddScoped<Infra.EmpresaContext>();
			services.AddScoped<IEmpresaService, EmpresaService>();


			builder.Services.AddProblemDetails();

			var app = builder.Build();

			app.MapHealthChecks("/health");

			app.MapsEmpresa();

			app.Run();
		}
	}

	public record Todo(int Id, string Title, DateOnly? DueBy = null, bool IsComplete = false);

	[JsonSerializable(typeof(Todo[]))]
	internal partial class AppJsonSerializerContext : JsonSerializerContext
	{

	}

	
}
