using Microsoft.AspNetCore.Mvc;
using System;
using TaxService.Services;

namespace TaxService.Controllers
{
  [Route("api/")]
  [ApiController]
  public class CalculateController : ControllerBase
  {

    private readonly ICalculateServices _calculateservices;

    public CalculateController(ICalculateServices services)
    {
      _calculateservices = services;
    }

    //Calculates tax rates
    [HttpGet]
    [Route("CalculateTax")]
    public ActionResult<double> CalculateTax(int id, DateTime date, int taxRule)
    {
      double taxedCities = _calculateservices.CalculateTax(id, date, taxRule);

      Console.WriteLine(taxedCities);

      return taxedCities;

    }
  }
}
