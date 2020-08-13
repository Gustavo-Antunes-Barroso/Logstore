using System.Collections.Generic;

namespace HungryPizza_Domain.Result
{
    public class TResult
    {
        #region <<< Constructor >>>
        public TResult()
        {
            Errors = new List<string>();
        }
        #endregion
        #region <<< Properties >>>
        public object Object { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        #endregion
    }
}
