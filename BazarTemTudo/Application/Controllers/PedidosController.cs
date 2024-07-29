using BazarTemTudo.Domain;
using BazarTemTudo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BazarTemTudo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public PedidosController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPedidos()
        {
            var allPedidos = dbContext.Pedidos.ToList();

            return Ok(allPedidos);

            
        }

    }
}
