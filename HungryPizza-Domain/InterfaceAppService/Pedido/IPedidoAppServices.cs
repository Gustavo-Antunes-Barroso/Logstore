using HungryPizza_Domain.Dto.Pedido;
using HungryPizza_Domain.Result;
using System;
using System.Threading.Tasks;

namespace HungryPizza_Domain.InterfaceAppService.Pedido
{
    public interface IPedidoAppServices
    {
        Task<TResult> InserirPedido(RequestPedidoDto pedido);
        Task<TResult> SelecionarPedido(Guid pedidoId);
    }
}
