namespace BazarTemTudo.Domain
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Dt_compra { get; set; }
        public required string Sku { get; set; }
        public int Quant_necessaria { get; set; }
    }
}
