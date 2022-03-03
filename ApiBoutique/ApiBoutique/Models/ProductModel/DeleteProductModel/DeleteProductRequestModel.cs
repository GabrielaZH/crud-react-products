using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Models.DeleteProductModel
{
    public class DeleteProductRequestModel:IModelValidator
    {
        public string Id { get; set; }

        public void ValidateModel()
        {
            if (Id == null)
            {
                throw new BadRequestException("El id del producto es requerido.");

            }
        }
    }
}
