using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBoutique.Models.Common;

namespace ApiBoutique.Models.GetAllProductModel
{
    public class GetAllProductsResponseModel
    {
        public List<ProductModel> Products { get; set; }
    }
}
