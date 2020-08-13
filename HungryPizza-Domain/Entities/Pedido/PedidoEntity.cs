using HungryPizza_Domain.Entities.Base;
using HungryPizza_Domain.Entities.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HungryPizza_Domain.Entities.Pedido
{
    [Table("Pedido")]
    public class PedidoEntity : EntityBase
    {
        #region <<< Constructor >>>
        public PedidoEntity()
        {
            Pizzas = new List<PizzaEntity>();
        }
        #endregion

        #region <<< Properties >>>
        [NotMapped]
        public virtual List<PizzaEntity> Pizzas { get; set; }
        public decimal ValorTotal { get; set; }
        #endregion

        #region <<< Methods >>>
        public bool ValidarPedido()
        {
            return Pizzas.Count <= 0 || Pizzas.Count > 10 ? false : true;
        }
        public void CalcularValorTotal()
        {
            if (ValidarPedido())
            {
                Pizzas.ToList().ForEach(x =>
                {
                    ValorTotal += x.ValorTotal;
                });
            }
        }
        #endregion
    }
}
