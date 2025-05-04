using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        public List<Data.Models.Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Data.Models.Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> CreateProduct(Data.Models.Product product)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> ArchiveProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
