using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Services
{
    public class TaxedCitiesServices : ITaxedCitiesServices
    {
        private readonly Dictionary<string, TaxedCities> _taxedCities;

        public TaxedCitiesServices()
        {
            _taxedCities = new Dictionary<string, TaxedCities>();
        }
        public TaxedCities AddTaxedCities(TaxedCities cities)
        {
            _taxedCities.Add(cities.Cityname, cities);

            return cities;
        }

        public Dictionary<string, TaxedCities> GetTaxedCities()
        {
            return _taxedCities;
            //throw new NotImplementedException();
        }

        public int GetTaxRule(string city)
        {
            return _taxedCities[city].TaxRule;
            //throw new NotImplementedException();
        }

    }
}
