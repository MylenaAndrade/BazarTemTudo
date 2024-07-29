namespace BazarTemTudo.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Dt_compra { get; set; }
        public DateTime Dt_pagamento { get; set; }
        public string? Status_pedido { get; set; }
        public int Preco_total { get; set; }
        public required string Cliente_id { get; set; }
        public int Quant_total { get; set; }
        public required string Servico_envio { get; set; }
        public required string Endereco_entrega1 { get; set; }
        public string? Endereco_entrega2 { get; set; }
        public string? Endereco_entrega3 { get; set; }
        public required string Cidade_entrega { get; set; }
        public required string Estado_entrega { get; set; }
        public required string Cep { get; set; }
        public required string Pais_entrega { get; set; }
    }
}
