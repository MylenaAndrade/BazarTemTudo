using Microsoft.EntityFrameworkCore;
using BazarTemTudo.Domain;

namespace BazarTemTudo.Infrastructure
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<ItensPedido>? ItensPedidos { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Compra>? Compras { get; set; }
        
    }
}