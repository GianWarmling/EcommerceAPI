namespace EcommerceAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Categoria { get; internal set; } = string.Empty;
        public bool Ativo { get; internal set; } = true;
        public DateTime CriadoEm { get; internal set; } = DateTime.UtcNow;
    }
}
