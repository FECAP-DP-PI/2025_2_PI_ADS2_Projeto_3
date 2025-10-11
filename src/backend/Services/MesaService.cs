using OneManDev_PI.Dtos.Mesa;
using OneManDev_PI.Models;
using OneManDev_PI.Repositories;

namespace OneManDev_PI.Services
{
    public class MesaService(MesaRepository mesaRepository)
    {
        public async Task<bool> CriarMesa(CriarMesaRequest request)
        {
            var mesaJaExiste = await mesaRepository.ExisteMesaComNumeroAsync(request.mesa);

            if (!mesaJaExiste)
            {
                var mesa = new Mesa(request.mesa);
                await mesaRepository.CriarMesa(mesa);
                return true;
            }

            return false;
        }

        public async Task<List<Mesa>> PegarMesasDisponiveis() => await mesaRepository.PegarMesasDisponiveis();

        public async Task<List<Mesa>> PegarMesas() => await mesaRepository.PegarMesas();
    }
   
}
