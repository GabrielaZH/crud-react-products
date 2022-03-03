using ApiBoutique.Models.AddProductModel;
using ApiBoutique.Models.DeleteProductModel;
using ApiBoutique.Models.GetAllProductModel;
using ApiBoutique.Models.GetProductByIDModel;
using ApiBoutique.Models.UpdateProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Services
{
    public interface IProductService
    {
        AddProductResponseModel Add(AddProductRequestModel request);

        UpdateProductResponseModel Update(UpdateProductRequestModel request);

        GetAllProductsResponseModel GetAll();

        GetProductByIdResponseModel GetById(GetProductByIdRequestModel request);

        void Delete(DeleteProductRequestModel request);

    }
}
