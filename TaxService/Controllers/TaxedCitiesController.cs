using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxService.Models;
using TaxService.Services;

namespace TaxService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaxedCitiesController : ControllerBase
    {
        private readonly ITaxedCitiesServices _services;
        public TaxedCitiesController(ITaxedCitiesServices services)
        {
            _services = services;
        }


        //Add cities and their tax rule number
        [HttpPost]
        [Route("AddTaxedCities")]
        public ActionResult <TaxedCities> AddTaxedCities(TaxedCities cityname)
        {
            var taxedCities = _services.AddTaxedCities(cityname);
            if(taxedCities == null)
            {
                return NotFound();
            }
            return taxedCities;
        }

        //Return all added cities
        [HttpGet]
        [Route("GetTaxedCities")]
        public ActionResult <Dictionary<string, TaxedCities>> GetTaxedCities()
        {
            var taxedCities = _services.GetTaxedCities();
            
            if(taxedCities.Count == 0)
            {
                return NotFound();
            }
            return taxedCities;
        }

        //Return Tax Rule number from City name
        [HttpGet]
        [Route("GetTaxRule")]
        public ActionResult<int> GetTaxRule(string city)
        {
            var taxedCities = _services.GetTaxRule(city);

            return taxedCities;
        }
    }
}