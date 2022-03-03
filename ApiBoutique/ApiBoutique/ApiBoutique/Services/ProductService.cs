using ApiBoutique.Entities;
using ApiBoutique.Models;
using ApiBoutique.Models.AddProductModel;
using ApiBoutique.Models.Common;
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
    public class ProductService : IProductService
    {
        private readonly DBContext _dbContext;

        public ProductService(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }
      
        /// <summary>
        /// Adds a new Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The product response Model</returns>
        public AddProductResponseModel Add(AddProductRequestModel request)
        {
            try
            {
                request.ValidateModel();

                AddProductResponseModel response = null;

                ProductEntity product = new ProductEntity
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price
                };

                this._dbContext.Product.Add(product);
                this._dbContext.SaveChanges();

                response = new AddProductResponseModel
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price
                };

                return response;
            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }
     
        /// <summary>
        /// Deletes a  product
        /// </summary>
        /// <param name="request"></param>
        public void Delete(DeleteProductRequestModel request)
        {
            try
            {
                ProductEntity productToDelete = this._dbContext.Product.Find(request.Id);

                if (productToDelete != null)
                {
                    this._dbContext.Remove(productToDelete);
                    this._dbContext.SaveChanges();
                }
                else
                {
                    throw new BadRequestException($"El producto con el id {request.Id} no existe");
                }
            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }

        }
        /// <summary>
        /// update a product
        /// </summary>
        /// <param name="transactionCode">Unique code per transaction</param>
        /// <param name="model">The request model</param>
        /// <returns>The product response model</returns>
        public UpdateProductResponseModel Update(UpdateProductRequestModel request)
        {
            try
            {
                request.ValidateModel();

                UpdateProductResponseModel response = null;

                ProductEntity productToEdit = this._dbContext.Product.Find(request.Id);

                if (productToEdit != null)
                {
                    productToEdit.Name = request.Name;
                    productToEdit.Description = request.Description;
                    productToEdit.Price = request.Price;

                    this._dbContext.Entry(productToEdit);
                    this._dbContext.SaveChanges();

                    response = new UpdateProductResponseModel
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Description = request.Description,
                        Price = request.Price
                    };

                    return response;
                }
                else
                {
                    throw new BadRequestException($"El producto a editar con el id {request.Id} no existe.");
                }

            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// <returns>The products response model</returns>
        public GetAllProductsResponseModel GetAll()
        {
            try
            {
                GetAllProductsResponseModel response = new GetAllProductsResponseModel();
                response.Products = new List<ProductModel>();

                List<ProductEntity> productsEntities = this._dbContext.Product.ToList();

                if (productsEntities == null)
                {
                    return null;
                }
                else
                {
                    ProductModel model = null;
                    foreach (var product in productsEntities)
                    {
                        model = new ProductModel
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price
                        };
                        response.Products.Add(model);

                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }


        /// <summary>
        /// Gets a Product by id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The product response model</returns>
        public GetProductByIdResponseModel GetById(GetProductByIdRequestModel request)
        {
            try
            {
                request.ValidateModel();

                GetProductByIdResponseModel response = null;

                ProductEntity productEntity = this._dbContext.Product.Find(request.Id);

                if (productEntity == null)
                {
                    throw new BadRequestException($"El producto con el id: {request.Id} no existe.");
                }
                response = new GetProductByIdResponseModel
                {
                    Product = new ProductModel
                    {
                        Id = productEntity.Id,
                        Name = productEntity.Name,
                        Description = productEntity.Description,
                        Price = productEntity.Price

                    }
                };
                return response;
            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }
    }

}
