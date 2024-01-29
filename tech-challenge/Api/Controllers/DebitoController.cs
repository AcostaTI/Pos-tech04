using Core.Application.UseCases.Debito;
using Core.Domain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
        public async Task<IActionResult> Post(DebitoInput req)
        {
            var debito = new Debito(
                Guid.NewGuid(),
                req.Valor,
                DateTime.Now,
                req.DataVencimento,
                req.Descricao,
                new Fornecedor(
                    Guid.NewGuid(),
                    req.NomeFornecedor
                )
            );

            //var nomeFila = _configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;
            //var endoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            //await endoint.Send(debito);
            await _bus.Publish( debito );
            return Ok(new DebitoOutput() { Result = new { Mensagem = "Adicionado na fila com sucesso!" } });
        }
    }
}
