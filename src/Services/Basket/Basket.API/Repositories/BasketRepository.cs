using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;
        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task Delete(string name)
        {
            await _cache.RemoveAsync(name);
        }

        public async Task<ShoppingCart> Get(string name)
        {
            var model = await _cache.GetStringAsync(name);
            if (model == null)
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(model);
        }

        public async Task<ShoppingCart> Update(ShoppingCart model)
        {
            await _cache.SetStringAsync(model.UserName, JsonConvert.SerializeObject(model));
            return await Get(model.UserName);
        }
    }
}
