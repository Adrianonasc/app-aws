using empresaApi.Infra.EntityConfig;
using Microsoft.Extensions.Configuration;

namespace empresaApi.Infra
{
	public class EmpresaContext() : DbContext
	{
		private readonly IConfiguration configuration;
		public EmpresaContext(IConfiguration configuration) : this()
		{
			this.configuration = configuration;
		}
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Responsavel> Responsaveis { get; set; }
		public DbSet<SituacaoCadastral> SituacoesCadastrais { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EmpresaConfig());
			modelBuilder.ApplyConfiguration(new ResponsavelConfig());
			modelBuilder.ApplyConfiguration(new SituacaoCadastralConfig());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);


			string conexao = configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseNpgsql(conexao, options => options.UseAdminDatabase("postgres"));

		}

	}
}
