using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MohanTestProject.Data
{
    // I have used Async and await so DB opersations are non blocking for performance improvement

    public class ProductService
    {
        private readonly MyDBContext _myContext; // instance for interaction with DB


        public ProductService(MyDBContext context)
        {
            _myContext = context;
        }


        public async Task<List<Product>> GetProducts()
        {
            return await _myContext.Products.ToListAsync();
        }


        public async Task<Product> GetProductAsync(int id)
        {
            return await _myContext.Products.FindAsync(id);
        }


        public async Task AddProductAsync(Product product)
        {
            _myContext.Products.Add(product);
            await _myContext.SaveChangesAsync();
        }

   
        public async Task UpdateProductAsync(Product product)
        {
            _myContext.Entry(product).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
        }


        public async Task DeleteProductAsync(int id)
        {
            var product = await _myContext.Products.FindAsync(id);
            if (product != null)
            {
                _myContext.Products.Remove(product);
                await _myContext.SaveChangesAsync();
            }
        }
    }
}
