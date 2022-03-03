using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Models.UpdateProductModel
{
    public class UpdateProductRequestModel:IModelValidator
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void ValidateModel()
        {
            if (string.IsNullOrEmpty(this.Id))
            {
                throw new BadRequestException("El identificador del producto es requerido.");
            }

            if (string.IsNullOrEmpty(this.Name))
            {
                throw new BadRequestException("El nombre del producto es requerido.");
            }
            if (string.IsNullOrEmpty(this.Description))
            {
                throw new BadRequestException("La descripción del producto es requerido.");
            }
            if (this.Price <= 0)
            {
                throw new BadRequestException("El precio del producto es requerido.");
            }
            if (this.Name.Length < 2)
            {
                throw new BadRequestException("El nombre del producto no puede ser tan corto.");

            }
            if (this.Name.Length > 90)
            {
                throw new BadRequestException("El nombre del producto no puede ser mayor a 90 caracteres.");

            }
            if (this.Description.Length > 300)
            {
                throw new BadRequestException("La descripción del producto no puede ser mayor a 300 caracteres.");

            }

        }
    }
}
