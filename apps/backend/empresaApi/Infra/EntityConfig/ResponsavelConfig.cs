
namespace empresaApi.Infra.EntityConfig
{
	class ResponsavelConfig : IEntityTypeConfiguration<Responsavel>
	{
		public void Configure(EntityTypeBuilder<Responsavel> builder)
		{
			builder.ToTable("responsaveis");

			builder.HasKey(r => r.Id);

			builder.Property(r => r.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(r => r.Nome)
				.HasColumnName("nome")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(r => r.CPF)
				.HasColumnName("cpf")
				.IsRequired()
				.HasMaxLength(11);

			builder.Property(r => r.Email)
				.HasColumnName("email")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(r => r.Telefone)
				.HasColumnName("telefone")
				.HasMaxLength(11);

		}
	}
}
