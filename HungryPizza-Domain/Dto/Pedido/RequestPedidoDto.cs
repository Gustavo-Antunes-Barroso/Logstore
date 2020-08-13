using HungryPizza_Domain.Dto.Pizza;
using System.Collections.Generic;

namespace HungryPizza_Domain.Dto.Pedido
{
    public class RequestPedidoDto
    {
        #region <<< Properties >>>
        public List<PizzaDto> Pizzas { get; set; }
        #endregion
    }
}
