using HungryPizza_Domain.Entities.Base;
using HungryPizza_Domain.Entities.Pedido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza_Domain.Entities.Pizza
{
    [Table("Pizza")]
    public class PizzaEntity : EntityBase
    {
        #region <<< Constructor >>>
        public PizzaEntity()
        {
            Sabores = new List<SaborEntity>();
        }
        #endregion

        #region <<< Properties >>>
        [NotMapped]
        public virtual List<SaborEntity> Sabores { get; set; }

        public decimal ValorTotal { get; set; }
        #endregion

        #region <<< Methods >>>
        public bool ValidarSabores()
        {
            return Sabores.Count <= 0 || Sabores.Count > 2 ? false : true;
        }
        public void CalcularValorTotal()
        {
            if (ValidarSabores())
            {
                Sabores.ForEach(x =>
                {
                    ValorTotal += x.Valor;
                });

                ValorTotal = ValorTotal / Sabores.Count;
            }
        }
        #endregion
    }
}
