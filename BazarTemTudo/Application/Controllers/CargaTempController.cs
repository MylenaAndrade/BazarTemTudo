using BazarTemTudo.Domain;
using BazarTemTudo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaTempController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CargaTempController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public async Task<IActionResult> AddCargaTemp([FromBody] AddTempCargaDTO addTempCarga)
        {
            var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf == addTempCarga.Cpf_cliente);
            if (cliente == null)
            {
                cliente = new Cliente()
                {
                    Email_cliente = addTempCarga.Email_cliente,
                    Nome_cliente = addTempCarga.Nome_cliente,
                    Cpf = addTempCarga.Cpf_cliente,
                    Tel_cliente = addTempCarga.Tel_cliente
                };
                await dbContext.Clientes.AddAsync(cliente);
            }

            var pedido = await dbContext.Pedidos.FirstOrDefaultAsync(c => c.Id == addTempCarga.Pedido_id);
            if (pedido == null)
            {
                pedido = new Pedido()
                {
                    Dt_compra = addTempCarga.Dt_compra,
                    Dt_pagamento = addTempCarga.Dt_pagamento,
                    Preco_total = addTempCarga.Preco_item * addTempCarga.Quant,
                    Cliente_id = cliente.Cpf,
                    Quant_total = addTempCarga.Quant,
                    Servico_envio = addTempCarga.Servico_envio,
                    Endereco_entrega1 = addTempCarga.Endereco_entrega1,
                    Endereco_entrega2 = addTempCarga.Endereco_entrega2,
                    Endereco_entrega3 = addTempCarga.Endereco_entrega3,
                    Cidade_entrega = addTempCarga.Cidade_entrega,
                    Estado_entrega = addTempCarga.Estado_entrega,
                    Cep = addTempCarga.Cep,
                    Pais_entrega = addTempCarga.Pais_entrega
                };
                await dbContext.Pedidos.AddAsync(pedido);
            }

            var produto = await dbContext.Produtos.FirstOrDefaultAsync(p => p.Sku == addTempCarga.Sku && p.Upc == addTempCarga.Upc);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            if (produto.Estoque >= addTempCarga.Quant)
            {
                produto.Estoque -= addTempCarga.Quant;
                pedido.Status_pedido = "Concluído";

            }
            else
            {
                pedido.Status_pedido = "Pendente";
                var compra = await dbContext.Compras.FirstOrDefaultAsync(c => c.Sku == addTempCarga.Sku);
                if (compra == null)
                {
                    compra = new Compra()
                    {
                        Sku = addTempCarga.Sku,
                        Quant_necessaria = addTempCarga.Quant * 3
                    };

                    await dbContext.Compras.AddAsync(compra);

                }
            }


            var itensPedido = await dbContext.ItensPedidos.FirstOrDefaultAsync(c => c.Pedido_id == addTempCarga.Pedido_id && c.Sku == produto.Sku);
            if (itensPedido == null)
            {
                itensPedido = new ItensPedido()
                {
                    Pedido_id = addTempCarga.Pedido_id,
                    Sku = addTempCarga.Sku,
                    Nome_produto = addTempCarga.Nome_produto,
                    Quant = addTempCarga.Quant,
                    Preco_item = addTempCarga.Preco_item
                };
                await dbContext.ItensPedidos.AddAsync(itensPedido);
            }

            await dbContext.SaveChangesAsync();
            return Ok("Dados adicionados com sucesso.");


        }

        [HttpPost("processar-pendentes")]
        public async Task<IActionResult> PedidosPendentes()
        {
            var pedidoPendente = await dbContext.Pedidos.Where(pp => pp.Status_pedido != "Concluído").OrderBy(pp => pp.Dt_compra).ToListAsync();
            

            foreach (var pedido in pedidoPendente)
            {
                var itensPedido = await dbContext.ItensPedidos.Where(ip => ip.Pedido_id == pedido.Id).ToListAsync();

                foreach (var itenspedido in itensPedido)
                {
                    var produto = await dbContext.Produtos.Where(p => p.Sku == itenspedido.Sku).ToListAsync();

                    foreach (var produ in produto)
                    {
                        if (produ.Estoque >= pedido.Quant_total)
                        {
                            produ.Estoque -= pedido.Quant_total;
                            pedido.Status_pedido = "Concluído";

                        }
                    }
                }

            }

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
