using HungryPizza_Domain.Entities.Base;

namespace HungryPizza_Domain.Dto.Pizza
{
    public class SaborDto : EntityBase
    {
        #region <<< Properties >>>
        public string Sabor { get; set; }
        public decimal Valor { get; set; }
        #endregion
    }
}
