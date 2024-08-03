using empresaApi.Infra;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace empresaApi.Apis
{
	public static class EmpresaController
	{
		public static IEndpointRouteBuilder MapsEmpresa(this IEndpointRouteBuilder app)
		{
			var api = app.MapGroup("api/empresa");
			api.MapGet("/", GetAll);
			api.MapGet("{empresaId:int}", GetAllById);
			api.MapGet("/situacaoCadastral", async ([FromServices] EmpresaContext context) => await context.SituacoesCadastrais.OrderBy(x => x.Id).ToListAsync());
			api.MapPost("/", async ([FromServices] EmpresaContext context, [FromBody] Empresa empresa) =>
			{
				await context.Empresas.AddAsync(empresa);
				await context.SaveChangesAsync();
				return TypedResults.Ok(empresa);
			});
			api.MapPut("{empresaId:int}", async ([FromServices] EmpresaContext context, [FromBody] Empresa empresa) =>
			{
				context.Empresas.Update(empresa);
				await context.SaveChangesAsync();
				return TypedResults.Ok(empresa);
			});

			return app;
		}

		private static async Task<Results<Ok<Empresa>, NotFound, BadRequest>> GetAllById(HttpContext context, [FromServices] EmpresaContext services)
		{
			var id = context.GetRouteValue("empresaId").ToString();
			if (!int.TryParse(id, out var empresaId))
			{
				context.Response.StatusCode = 400;
				await context.Response.WriteAsync("Id inválido");
				return TypedResults.BadRequest();
			}

			var empresa = await services.Empresas.FindAsync(empresaId);
			if (empresa == null)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync("Empresa não encontrada");
				return TypedResults.NotFound();
			}

			return TypedResults.Ok(empresa);
		}

		public static async Task<Ok<List<Empresa>>> GetAll([FromServices] EmpresaContext services)
		{
			var items = await services.Empresas.ToListAsync();
			return TypedResults.Ok(items);
		}




	}
}
