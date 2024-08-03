namespace empresaApi.Model
{
	public class Empresa()
	{
		public int Id { get; set; }
		public string Cnpj { get; set; }
		public string RazaoSocial { get; set; }
		public DateTime DataAbertura { get; set; }
		public DateTime? DataTermino { get; set; }

		public virtual Responsavel ResponsavelFiscal { get; set; }
		public int? ResponsavelFiscalId { get; set; }

		public virtual SituacaoCadastral SituacaoCadastral { get; set; }
		public int SituacaoCadastralId { get; set; }
		public string Cnae { get; set; }
		public decimal? Fap { get; set; }
		public decimal? Rat { get; set; }
	}
}
