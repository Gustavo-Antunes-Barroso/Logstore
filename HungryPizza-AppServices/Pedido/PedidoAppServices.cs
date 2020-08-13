using System;
using System.Threading.Tasks;
using AutoMapper;
using HungryPizza_Domain.Dto.Pedido;
using HungryPizza_Domain.Entities.Pedido;
using HungryPizza_Domain.InterfaceAppService.Pedido;
using HungryPizza_Domain.InterfaceRepository.Pedido;
using HungryPizza_Domain.Result;

namespace HungryPizza_AppServices.Pedido
{
    public class PedidoAppServices : IPedidoAppServices
    {
        #region <<< Constructor >>>
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoAppServices(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        #endregion

        #region <<< Methods >>>
        public async Task<TResult> InserirPedido(RequestPedidoDto pedido)
        {
            var obj = _mapper.Map<PedidoEntity>(pedido);
            var response = new TResult();

            if (!obj.ValidarPedido())
                response.Errors.Add("Seu pedido deve conter de 0 a 10 pizzas!");

            obj.Pizzas.ForEach(x =>
            {
                if (!x.ValidarSabores())
                    response.Errors.Add("Pizza deve ter 1 ou 2 sabores!");

                x.CalcularValorTotal();
            });

            if (response.Errors.Count <= 0)
            {
                obj.CalcularValorTotal();

                response.Object = await _pedidoRepository.InserirPedido(obj);
                response.Success = true;
                return response;
            }

            response.Object = obj;
            return response;
        }

        public async Task<TResult> SelecionarPedido(Guid pedidoId)
        {
            var response = new TResult();
            var obj = await _pedidoRepository.SelecionarPedido(pedidoId);

            if (obj == null)
            {
                response.Errors.Add("Pedido não encontrado!");
                return response;
            }

            response.Object = obj;
            response.Success = true;
            return response;
        }
        #endregion
    }
}
