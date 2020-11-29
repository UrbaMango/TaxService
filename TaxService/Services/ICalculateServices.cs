using System;

namespace TaxService.Services
{
    public interface ICalculateServices
    {
        double CalculateTax(int id, DateTime date);
    }
}
