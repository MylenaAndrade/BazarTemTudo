using BazarTemTudo.Domain;
using BazarTemTudo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BazarTemTudo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ProdutosController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            var allProdutos = dbContext.Produtos.ToList();

            return Ok(allProdutos);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto Produtos)
        {
            var produtoEntity = new Produto()
            {
                Sku = Produtos.Sku,
                Upc = Produtos.Upc,
                Nome_produto = Produtos.Nome_produto,

            };

            await dbContext.Produtos.AddAsync(produtoEntity);
            dbContext.SaveChanges();

            return Ok(produtoEntity);
        }

        [HttpPost("atualizar-estoque")]
        public async Task<IActionResult> AtualizarProdutos()
        {
            var produtos = await dbContext.Produtos.ToListAsync();
            var compras = await dbContext.Compras.ToListAsync();

            var comprasARemover = new List<Compra>();

            foreach (var compra in compras)
            {
                foreach (var produto in produtos)
                {
                    if(compra.Sku == produto.Sku)
                    {
                        produto.Estoque = compra.Quant_necessaria;
                        comprasARemover.Add(compra);
                    }
                }
            }

            dbContext.Compras.RemoveRange(comprasARemover);

            await dbContext.SaveChangesAsync();

            return Ok("Estoque Atualizado com Sucesso");
        }

    }
}
