using HungryPizza_Domain.Dto.Pizza;
using System;
using System.Collections.Generic;

namespace HungryPizza_Domain.Dto.Pedido
{
    public class ResponsePedidoDto
    {
        #region <<< Constructor >>>
        public ResponsePedidoDto()
        {
            Pizzas = new List<PizzaDto>();
        }
        #endregion

        #region <<< Properties >>>
        public Guid PedidoId { get; set; }
        public decimal PedidoValor { get; set; }
        public List<PizzaDto> Pizzas { get; set; }
        #endregion
    }
}
