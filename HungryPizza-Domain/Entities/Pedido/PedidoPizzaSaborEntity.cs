using HungryPizza_Domain.Entities.Base;
using HungryPizza_Domain.Entities.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza_Domain.Entities.Pedido
{
    [Table("PedidoPizzaSabor")]
    public class PedidoPizzaSaborEntity : EntityBase
    {
        public Guid PedidoId { get; set; }
        public Guid PizzaId { get; set; }
        public Guid SaborId { get; set; }
    }
}
