using BazarTemTudo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ComprasController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCompras()
        {
            var allCompras = dbContext.Compras.ToList();

            return Ok(allCompras);
        }
    }
}
