using Catalog.API.Models;
using Catalog.API.Models.Dto;
using Catalog.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> GetProducts()
        {
            try
            {
                var products = await _repository.GetProducts();
                _response.Result = products;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public async Task<object> GetProductById(string id)
        {
            try
            {
                var product = await _repository.GetProductById(id);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        public async Task<object> GetProductByCategory(string category)
        {
            try
            {
                var product = await _repository.GetProductByCategory(category);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Route("[action]/{name}", Name = "GetProductByName")]
        [HttpGet]
        public async Task<object> GetProductByName(string name)
        {
            try
            {
                var product = await _repository.GetProductByName(name);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> CreateProduct([FromBody] Product product)
        {
            try
            {
                var model = await _repository.CreateProduct(product);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> UpdateProduct([FromBody] Product product)
        {
            try
            {
                var isSuccess = await _repository.UpdateProduct(product);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        public async Task<object> DeleteProductById(string id)
        {
            try
            {
                var isSuccess = await _repository.DeleteProductById(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
