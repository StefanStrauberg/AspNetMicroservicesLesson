using Catalog.API.DbContexts;
using Catalog.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _db;
        public ProductRepository(ICatalogContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            await _db.Products.InsertOneAsync(product);
            return (!String.IsNullOrEmpty(product.Id));
        }

        public async Task<bool> DeleteProductById(string productId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, productId);
            DeleteResult deleteResult = await _db.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProductById(string productId)
        {
            Product product = await _db.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> productList = await _db.Products.Find(p => true).ToListAsync();
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            List<Product> productList = await _db.Products.Find(filter).ToListAsync();
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            List<Product> productList = await _db.Products.Find(filter).ToListAsync();
            return productList;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            ReplaceOneResult updateResult = await _db.Products.ReplaceOneAsync(filter, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
