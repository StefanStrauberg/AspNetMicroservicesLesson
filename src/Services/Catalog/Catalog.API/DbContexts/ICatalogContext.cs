using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.DbContexts
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
