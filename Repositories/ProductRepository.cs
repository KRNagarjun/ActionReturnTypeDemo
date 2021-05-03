using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerActionReturnTypeDemo.Models;

namespace ControllerActionReturnTypeDemo.Repositories
{
    public class ProductRepository
    {
        private readonly ProductContext _context;

        public List<Product> GetProducts() =>
          _context.Products.OrderBy(p => p.Name).ToList();

        public bool TryGetProduct(int id, out Product product)
        {
            product = _context.Products.Find(id);

            return (product != null);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
