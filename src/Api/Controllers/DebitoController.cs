using Core.Domain.Entidades;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Consumidor.Controllers
{
    [ApiController]
    [Route("/Debito")]
    public class DebitoController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public DebitoController(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var nomeFila = _configuration
                .GetSection("MassTransit")["NomeFila"] ?? string.Empty;
            var endoint = await _bus
                .GetSendEndpoint(new Uri($"quere:{nomeFila}"));

            await endoint.Send(new Debito("1", 50000, DateTime.Now,DateTime.Now, "custos diarios", new Fornecedor("1", "Mercado do fulano")));
            return Ok();
        }
    }
}
