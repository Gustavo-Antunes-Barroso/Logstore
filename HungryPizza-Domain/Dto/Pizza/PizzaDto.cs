using System;
using System.Collections.Generic;

namespace HungryPizza_Domain.Dto.Pizza
{
    public class PizzaDto
    {
        #region <<< Properties >>>
        public List<SaborDto> Sabores { get; set; }
        public decimal Valor { get; set; }
        public Guid PizzaId { get; set; }
        #endregion
    }
}
