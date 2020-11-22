using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Services
{
    public interface ICalculateServices
    {
        double CalculateTax(string city, DateTime date);
    }
}
