using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Models
{
    public interface IModelValidator
    {
        /// <summary>
        /// Throws an exception 
        /// </summary>
        void ValidateModel();
    }
}
