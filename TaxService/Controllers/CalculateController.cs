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
    public class CalculateController : ControllerBase
    {

        private readonly ICalculateServices _services;

        public CalculateController(ICalculateServices services)
        {
            _services = services;
        }

        //Calculates tax rates
        [HttpGet]
        [Route("CalculateTax")]
        public ActionResult <double> CalculateTax(string city, DateTime date)
        {
            double taxedCities = _services.CalculateTax(city, date);

            return taxedCities;

        }
    }
}