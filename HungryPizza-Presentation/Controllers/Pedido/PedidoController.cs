using System;
using System.Net.Mime;
using System.Threading.Tasks;
using HungryPizza_Domain.Dto.Pedido;
using HungryPizza_Domain.InterfaceAppService.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza_Presentation.Controllers.Pedido
{
    [Route("[controller]")]
    [ApiController]
    //Comunicacao da api
    [Produces(MediaTypeNames.Application.Json)]
    public class PedidoController : ControllerBase
    {
        #region <<< Constructor >>>
        private readonly IPedidoAppServices _pedidoServices;
        public PedidoController(IPedidoAppServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }
        #endregion

        #region <<< Methods >>>
        [HttpGet, Route("SelecionarPedido")]
        public async Task<IActionResult> Get([FromQuery] Guid pedidoId)
        {
            var response = await _pedidoServices.SelecionarPedido(pedidoId);
            return Ok(response);
        }

        [HttpPut, Route("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] RequestPedidoDto pedido)
        {
            var response = await _pedidoServices.InserirPedido(pedido);
            return Ok(response);
        }
        #endregion
    }
}
