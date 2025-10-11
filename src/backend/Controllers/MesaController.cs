using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneManDev_PI.Dtos.Mesa;
using OneManDev_PI.Services;

namespace OneManDev_PI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController(MesaService mesaService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CriarMesa([FromBody] CriarMesaRequest request)
        {
            var criada = await mesaService.CriarMesa(request);

            if (criada)
                return Ok(new { mensagem = "Mesa criada com sucesso!" });
            else
                return BadRequest(new { mensagem = $"Já existe uma mesa com o número {request.mesa}." });
        }

        [HttpGet("disponiveis")]
        public async Task<IActionResult> PegarMesasDisponiveis()
        {
            var mesas = await mesaService.PegarMesasDisponiveis();
            return Ok(mesas);
        }

        [HttpGet]
        public async Task<IActionResult> PegarMesas()
        {
            var mesas = await mesaService.PegarMesas();
            return Ok(mesas);
        }
    }
}
