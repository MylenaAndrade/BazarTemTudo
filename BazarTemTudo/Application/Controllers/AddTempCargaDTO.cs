namespace BazarTemTudo.Application.Controllers
{
    public class AddTempCargaDTO
    {
        public int Pedido_id { get; set; }
        public int Item_pedido_id { get; set; }
        public DateTime Dt_compra { get; set; }
        public DateTime Dt_pagamento { get; set; }
        public required string Email_cliente { get; set; }
        public required string Nome_cliente { get; set; }
        public required string Cpf_cliente { get; set; }
        public required string Tel_cliente { get; set; }
        public required string Sku { get; set; }
        public required string Upc { get; set; }
        public required string Nome_produto { get; set; }
        public required int Quant { get; set; }
        public int Preco_item { get; set; }
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
