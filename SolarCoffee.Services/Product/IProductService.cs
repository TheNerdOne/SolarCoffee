using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Product
{
    public interface IProductService
    {
        ServiceResponse<List<Data.Models.Product>> GetAllProducts();
        ServiceResponse<Data.Models.Product> GetProductById(int id);
        ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product);
        ServiceResponse<Data.Models.Product> ArchiveProduct(int id);
        ServiceResponse<bool> UpdateProduct(Data.Models.Product product);

    }
}
