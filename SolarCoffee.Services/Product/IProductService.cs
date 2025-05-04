using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Product
{
    public interface IProductService
    {
        List<Data.Models.Product> GetAllProducts();
        Data.Models.Product GetProductById(int id);
        ServiceResponse<bool> CreateProduct(Data.Models.Product product);
        ServiceResponse<bool> ArchiveProduct(int id);
        ServiceResponse<bool> UpdateProduct(Data.Models.Product product);

    }
}
