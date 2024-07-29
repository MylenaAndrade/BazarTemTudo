namespace BazarTemTudo.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Sku { get; set; }
        public required string Upc { get; set; }
        public required string Nome_produto { get; set; }
        public int Estoque { get; set; }
    }
}
