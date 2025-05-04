using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public required string Message { get; set; }
        public DateTime Time { get; set; }
        public required T Data { get; set; }
    }
}
