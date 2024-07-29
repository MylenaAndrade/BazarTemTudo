namespace BazarTemTudo.Domain
{
    public class ItensPedido
    {
        public int Id { get; set; }
        public int Pedido_id { get; set; }
        public required string Sku { get; set; }
        public string? Nome_produto { get; set; }
        public int Quant { get; set; }
        public int Preco_item { get; set; }
    }
}
