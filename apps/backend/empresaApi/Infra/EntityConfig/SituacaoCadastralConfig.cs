namespace empresaApi.Infra.EntityConfig
{
	public class SituacaoCadastralConfig : IEntityTypeConfiguration<SituacaoCadastral>
	{
		public void Configure(EntityTypeBuilder<SituacaoCadastral> builder)
		{
			builder.ToTable("situacao_cadastral");

			builder.HasKey(sc => sc.Id);

			builder.Property(sc => sc.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(sc => sc.Descricao)
				.HasColumnName("descricao")
				.IsRequired()
				.HasMaxLength(100);

		}
	}
}
