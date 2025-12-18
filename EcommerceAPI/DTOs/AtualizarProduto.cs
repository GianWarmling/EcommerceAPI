namespace EcommerceAPI.DTOs
{
    public class AtualizarProduto
    {
        public string Name { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
