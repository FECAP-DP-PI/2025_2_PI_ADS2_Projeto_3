using Microsoft.EntityFrameworkCore;
using OneManDev_PI.Models;

namespace OneManDev_PI.Repositories
{
    public class MesaRepository(AppDbContext context)
    {
        public async Task<List<Mesa>> PegarMesasDisponiveis()
        {
            var mesas = await context.Mesas
                .Where(m => m.Status == 0)
                .ToListAsync();

            return mesas;
        }
        
        public async Task<List<Mesa>> PegarMesas()
        {
            var mesas = await context.Mesas
                .ToListAsync();

            return mesas;
        }

        public async Task CriarMesa(Mesa mesa)
        {
            await context.Mesas.AddAsync(mesa);
            await context.SaveChangesAsync();
            return;
        }

        public async Task<bool> ExisteMesaComNumeroAsync(int numeroMesa)
        {
            return await context.Mesas.AnyAsync(m => m.Numero == numeroMesa);
        }

    }
}
