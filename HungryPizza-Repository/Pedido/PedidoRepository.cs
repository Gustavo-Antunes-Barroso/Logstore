using HungryPizza_Domain.Entities.Pedido;
using HungryPizza_Domain.InterfaceRepository.Pedido;
using System;
using System.Threading.Tasks;
using repositorio = HungryPizza_Repository.Context;
using System.Linq;
using HungryPizza_Domain.Dto.Pedido;
using AutoMapper;
using HungryPizza_Domain.Dto.Pizza;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HungryPizza_Domain.Entities.Pizza;

namespace HungryPizza_Repository.Pedido
{
    public class PedidoRepository : IPedidoRepository
    {
        #region <<< Constructor >>>
        private readonly repositorio.Context _db;
        private readonly IMapper _mapper;
        public PedidoRepository(repositorio.Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        #endregion

        #region <<< Methods >>>
        public async Task<PedidoEntity> InserirPedido(PedidoEntity pedidos)
        {
            await _db.Pedido.AddAsync(pedidos);
            _db.SaveChanges();

            AdicionarPizzas(pedidos.Pizzas);
            AdicionarPizzasSabores(pedidos.Pizzas, pedidos.Id);

            return pedidos;
        }
        public async Task<ResponsePedidoDto> SelecionarPedido(Guid pedidoId)
        {
            var query = await BuscarPedido(pedidoId);
            if (query != null)
                query.Pizzas = await BuscarPizzas(pedidoId);

            return query;
        }
        private void AdicionarPizzas(List<PizzaEntity> pizzas)
        {
            pizzas.ForEach(pizza =>
            {
                _db.Pizza.Add(pizza);

            });

            _db.SaveChanges();
        }
        private void AdicionarPizzasSabores(List<PizzaEntity> pizzas, Guid pedidoId)
        {
            pizzas.ForEach(pizza =>
            {
                pizza.Sabores.ForEach(sabor =>
                {
                    _db.PedidoPizzaSabor.Add(
                        new PedidoPizzaSaborEntity()
                        {
                            PedidoId = pedidoId,
                            PizzaId = pizza.Id,
                            SaborId = sabor.Id
                        }
                    );
                });
            });
            _db.SaveChanges();
        }
        private async Task<ResponsePedidoDto> BuscarPedido(Guid pedidoId)
        {
            var query = await (from ped in _db.Pedido
                               where ped.Id == pedidoId
                               select new ResponsePedidoDto()
                               {
                                   PedidoId = ped.Id,
                                   PedidoValor = ped.ValorTotal
                               }).FirstOrDefaultAsync();
            return query;
        }
        private async Task<List<PizzaDto>> BuscarPizzas(Guid pedidoId)
        {
            var query = await (from pps in _db.PedidoPizzaSabor
                               join ped in _db.Pedido on pps.PedidoId equals ped.Id
                               join piz in _db.Pizza on pps.PizzaId equals piz.Id
                               where pps.PedidoId == pedidoId
                               select new PizzaDto()
                               {
                                   PizzaId = piz.Id,
                                   Valor = piz.ValorTotal,
                                   Sabores = _mapper.Map<List<SaborDto>>(
                                             (from sab in _db.Sabor
                                              join pps in _db.PedidoPizzaSabor on sab.Id equals pps.SaborId
                                              where pps.PedidoId == pedidoId
                                              && pps.PizzaId == piz.Id
                                              select sab).ToList())
                               }).Distinct().ToListAsync();
            return query;
        }
        #endregion
    }
}
