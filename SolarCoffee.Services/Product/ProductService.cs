using System;
using System.Collections.Generic;
using System.Text;
using SolarCoffee.Data;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        private SolarDbContext _context = new SolarDbContext();
        public ServiceResponse<List<Data.Models.Product>> GetAllProducts()
        {
            // Check if the database is empty
            if (_context.Products == null)
            {
                throw new Exception("Database is not initialized");
            }
            var products = _context.Products.Where(p => !p.IsArchived).ToList();
            if (products == null || products.Count == 0)
            {
                throw new Exception("No products found");
            }
            return new ServiceResponse<List<Data.Models.Product>>
            {
                Data = products,
                Message = "Products retrieved successfully",
                IsSuccess = true,
                Time = DateTime.UtcNow
            };
        }

        public ServiceResponse<Data.Models.Product> GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }
            return new ServiceResponse<Data.Models.Product>
            {
                Data = product,
                Message = "Product retrieved successfully",
                IsSuccess = true,
                Time = DateTime.UtcNow
            };
        }

        public ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product)
        {
            try
            {
                product.CreatedOn = DateTime.UtcNow;
                product.UpdatedOn = DateTime.UtcNow;
                product.IsArchived = false;

                _context.Products.Add(product);

                var newInventory = new Data.Models.ProductInventory
                {
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    Product = product,
                    QuatityOnHand = 0,
                    IdealQuantity = 10,
                };
                _context.ProductInventories.Add(newInventory);

                _context.SaveChanges();

                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = $"Product created successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    IsSuccess = false,
                    Message = $"Error creating product: {ex.Message}"
                };
            }
        }

        public ServiceResponse<Data.Models.Product> ArchiveProduct(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return new ServiceResponse<Data.Models.Product>
                    {
                        Data = null,
                        Message = $"Product with {id} not found",
                        IsSuccess = false,
                        Time = DateTime.UtcNow
                    };
                }
                product.IsArchived = true;
                _context.SaveChanges();
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Message = "Product archived successfully",
                    IsSuccess = true,
                    Time = DateTime.UtcNow
                };
            }
            catch (System.Exception e)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = null,
                    Message = $"error:{e}",
                    IsSuccess = false,
                    Time = DateTime.UtcNow
                };
            }
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
