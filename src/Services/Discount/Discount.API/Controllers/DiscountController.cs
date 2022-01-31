using Discount.API.Models.Dto;
using Discount.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        protected ResponseDto _response;
        private IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        [Route("{ProductName}")]
        public async Task<object> Get(string ProductName)
        {
            try
            {
                var coupon = await _discountRepository.GetCouponByName(ProductName);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] CouponDto couponDto)
        {
            try
            {
                var model = await _discountRepository.CreateUpdateCoupon(couponDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var model = await _discountRepository.CreateUpdateCoupon(couponDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{CouponId}")]
        public async Task<object> Delete(int CouponId)
        {
            try
            {
                bool isSuccess = await _discountRepository.DeleteCoupon(CouponId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
