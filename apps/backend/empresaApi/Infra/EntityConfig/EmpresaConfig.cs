
namespace empresaApi.Infra.EntityConfig
{
	public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
	{
		public void Configure(EntityTypeBuilder<Empresa> builder)
		{
			builder.ToTable("empresas");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(e => e.Cnpj)
				.HasColumnName("cnpj")
				.IsRequired()
				.HasMaxLength(14);

			builder.Property(e => e.RazaoSocial)
				.HasColumnName("razao_social")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(e => e.DataAbertura)
				.HasColumnName("data_abertura")
				.IsRequired();

			builder.Property(e => e.DataTermino)
				.HasColumnName("data_termino");

			builder.Property(e => e.Rat)
				.HasColumnName("rat")
				.IsRequired();

			builder.Property(e => e.Fap)
				.HasColumnName("fap");

			builder.Property(e => e.Cnae)
				.HasColumnName("cnae")
				.IsRequired();

			builder.Property(e => e.SituacaoCadastralId)
				.HasColumnName("situacao_cadastral_id")
				.IsRequired();

			builder.HasOne(e => e.SituacaoCadastral)
				.WithMany()
				.HasForeignKey(e => e.SituacaoCadastralId);

			builder.Property(e => e.ResponsavelFiscalId)
				.HasColumnName("responsavel_fiscal_id")
				.IsRequired();

			builder.HasOne(e => e.ResponsavelFiscal)
				.WithMany()
				.HasForeignKey(e => e.ResponsavelFiscalId);
		}
	}
}
