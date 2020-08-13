using HungryPizza_Domain.Dto.Pedido;
using HungryPizza_Domain.Entities.Pedido;
using System;
using System.Threading.Tasks;

namespace HungryPizza_Domain.InterfaceRepository.Pedido
{
    public interface IPedidoRepository
    {
        Task<PedidoEntity> InserirPedido(PedidoEntity pedido);
        Task<ResponsePedidoDto> SelecionarPedido(Guid pedidoId);
    }
}
