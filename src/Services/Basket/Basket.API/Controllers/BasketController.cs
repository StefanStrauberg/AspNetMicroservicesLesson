using Basket.API.GRPCServices;
using Basket.API.Models;
using Basket.API.Models.Dto;
using Basket.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        protected ResponseDto _response;
        private readonly DiscountGrpcService _discountGrpcService;
        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService)
        {
            _repository = repository;
            this._response = new ResponseDto();
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        public async Task<object> GetBasket(string userName)
        {
            try
            {
                _response.Result = await _repository.GetBasket(userName);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                //GRPC Communication
                foreach (var item in basket.Items)
                {
                    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                    item.Price -= coupon.Amount;
                }
                //CRUD
                _response.Result = await _repository.UpdateBasket(basket);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        public async Task<object> DeleteBasket(string userName)
        {
            try
            {
                var isSuccess = await _repository.DeleteBasket(userName);
                _response.IsSuccess = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
