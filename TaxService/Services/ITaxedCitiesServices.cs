using System.Collections.Generic;
using TaxService.Models;

namespace TaxService.Services
{
  public interface ITaxedCitiesServices
  {
        IEnumerable<TaxedCities> FindAll();
        TaxedCities AddTaxedCities(TaxedCities cities);
        int Delete(int id);
        bool Update(TaxedCities forecast);
        int GetTaxRule(int id);
        TaxedCities FindOne(int id);
  }
}
