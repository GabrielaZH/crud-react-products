using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Models.GetProductByIDModel
{
    public class GetProductByIdRequestModel:IModelValidator
    {
        public string Id { get; set; }

        public void ValidateModel()
        {
            if (string.IsNullOrEmpty(this.Id))
            {
                throw new BadRequestException("El identificador del producto es requerido.");
            }

        }
    }
}
