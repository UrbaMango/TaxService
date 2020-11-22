using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Services
{
    public interface ITaxedCitiesServices
    {
        TaxedCities AddTaxedCities(TaxedCities cities);
        Dictionary<string, TaxedCities> GetTaxedCities();
        int GetTaxRule(string city);
    }
}
