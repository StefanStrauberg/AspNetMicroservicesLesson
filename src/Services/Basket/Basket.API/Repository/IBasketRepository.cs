using Basket.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket.API.Repository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task<bool> DeleteBasket(string userName);
    }
}
