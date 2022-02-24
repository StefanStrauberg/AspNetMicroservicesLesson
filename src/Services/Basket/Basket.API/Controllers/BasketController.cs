using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;
        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService)
        {
            _repository = repository;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet("{name}", Name = "Get")]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> Get(string name)
        {
            return Ok(await _repository.Get(name) ?? new ShoppingCart(name));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> Update([FromBody] ShoppingCart model)
        {
            foreach (var item in model.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
            return Ok(await _repository.Update(model));
        }

        [HttpDelete("{name}",Name = "Delete")]
        [ProducesResponseType(typeof(void),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(string name)
        {
            await _repository.Delete(name);
            return Ok();
        }
    }
}
