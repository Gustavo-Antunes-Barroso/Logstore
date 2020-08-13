using HungryPizza_Domain.Entities.Base;

namespace HungryPizza_Domain.Entities.Pizza
{
    public class SaborEntity : EntityBase
    {
        #region <<< Properties >>>
        public string Sabor { get; set; }
        public decimal Valor { get; set; }
        #endregion
    }
}
