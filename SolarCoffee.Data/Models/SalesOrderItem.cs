using System;

namespace SolarCoffee.Data.Models
{
    public class SalesOrderItem
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public Product Product { get; set; }
    }
}