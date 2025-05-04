using System;
using System.Collections.Generic;
using System.Text;
using SolarCoffee.Data;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        private SolarDbContext _context = new SolarDbContext();
        public List<Data.Models.Product> GetAllProducts()
        {
            // Check if the database is empty
            if (_context.Products == null)
            {
                throw new Exception("Database is not initialized");
            }
            var products = _context.Products.ToList();
            if (products == null || products.Count == 0)
            {
                throw new Exception("No products found");
            }
            products = products.Where(p => !p.IsArchived).ToList();
            return products;
        }

        public Data.Models.Product GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }
            return product;
        }

        public ServiceResponse<bool> CreateProduct(Data.Models.Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Product created successfully"
            };
        }

        public ServiceResponse<bool> ArchiveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }
            product.IsArchived = true;
            _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Product archived successfully"
            };
        }
        public ServiceResponse<bool> UpdateProduct(Data.Models.Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                throw new Exception($"Product with id {product.Id} not found");
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.IsArchived = product.IsArchived;
            _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Product updated successfully"
            };
        }
        public ServiceResponse<bool> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Product deleted successfully"
            };
        }
    }
}
