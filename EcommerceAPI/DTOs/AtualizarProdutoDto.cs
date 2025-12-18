namespace EcommerceAPI.DTOs
{
    public class AtualizarProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string? ImagemUrl { get; set; }
        public bool Ativo { get; set; }
    }
}
