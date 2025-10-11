using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OneManDev_PI.Models;
using System.Diagnostics.SymbolStore;

namespace OneManDev_PI.Repositories
{
    public class PedidoRepository(AppDbContext context)
    {
        public async Task<Pedido> PegarPedidoPorId(int id) {

            var pedido = await context.Pedidos
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return pedido;
        }

        public async Task CriarPedido(Pedido pedido)
        {
            await context.Pedidos.AddAsync(pedido);
            await context.SaveChangesAsync();
            return; 
        }
    }
}
