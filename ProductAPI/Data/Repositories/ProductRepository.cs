using MongoDB.Driver;
using ProductAPI.Data.Interfaces;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductAPI.Data.Config;

namespace ProductAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository()
        {
            _products = MongoDbSettings.Db.GetCollection<Product>("products");
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await _products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _products.Find(filter).ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var deleteResult = await _products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
