using ApiBoutique.Models;
using ApiBoutique.Models.AddProductModel;
using ApiBoutique.Models.DeleteProductModel;
using ApiBoutique.Models.GetAllProductModel;
using ApiBoutique.Models.GetProductByIDModel;
using ApiBoutique.Models.UpdateProductModel;
using ApiBoutique.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public readonly IProductService _productService;

        #region Constructors
        public ProductController(IProductService productService)
        {
            this._productService = productService;

        }
        #endregion

        #region Methods

 
        /// <summary>
        /// This method adds a new product.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>a product response model</returns>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AddProductResponseModel> GetById([FromBody] AddProductRequestModel request)
        {
            try
            {
                AddProductResponseModel response = this._productService.Add(request: request);


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method Updates a  Product.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A Product response model</returns>
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UpdateProductResponseModel> Update([FromBody] UpdateProductRequestModel request)
        {
            try
            {
                UpdateProductResponseModel response = this._productService.Update(request: request);


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method deletes a  Product.
        /// </summary>
        /// <param name="model">The request model</param>
        [HttpPost("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete([FromBody] DeleteProductRequestModel request)
        {
            try
            {
                this._productService.Delete(request: request);
                return new OkResult();
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }

        /// <summary>
        /// This method gets all the Products.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A Product response model</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GetAllProductsResponseModel> GetAll()
        {
            try
            {
                GetAllProductsResponseModel response = this._productService.GetAll();


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method gets a Product by unique id.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A Product response model</returns>
        [HttpPost("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GetProductByIdResponseModel> GetById([FromBody] GetProductByIdRequestModel request)
        {
            try
            {
                GetProductByIdResponseModel response = this._productService.GetById(request: request);


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }

        #endregion

    }
}
