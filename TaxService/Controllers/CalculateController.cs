using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult<double> CalculateTax(int id, DateTime date)
        {
            double taxedCities = _services.CalculateTax(id, date);

            return taxedCities;

        }
    }
}