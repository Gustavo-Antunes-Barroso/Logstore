using System;
using System.ComponentModel.DataAnnotations;

namespace HungryPizza_Domain.Entities.Base
{
    public abstract class EntityBase
    {
        #region <<< Constructor >>>
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        #endregion

        #region <<< Properties >>>
        [Key]
        public Guid Id { get; set; }
        #endregion
    }
}
