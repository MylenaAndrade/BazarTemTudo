using BazarTemTudo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidosController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ItensPedidosController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllItensPedidos()
        {
            var allItensPedidos = dbContext.ItensPedidos.ToList();

            return Ok(allItensPedidos);
        }
    }
}
