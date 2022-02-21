using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> Get(string name);
        Task<ShoppingCart> Update(ShoppingCart model);
        Task Delete(string name);
    }
}
