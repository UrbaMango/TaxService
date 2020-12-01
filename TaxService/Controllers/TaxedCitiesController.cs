using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

    
    [HttpGet]
    [Route("GetAllCities")]
    public IEnumerable<TaxedCities> Get()
    {
      Console.WriteLine(_services.FindAll());
      return _services.FindAll();
    }

    //Add cities and their tax rule number
    [HttpPost]
    [Route("AddCity")]
    public ActionResult<TaxedCities> AddTaxedCities(TaxedCities cityname)
    {
      var taxedCities = _services.AddTaxedCities(cityname);
      if (taxedCities == null)
      {
        return NotFound();
      }
      return taxedCities;
    }
    [HttpPut]
    public ActionResult<TaxedCities> Update(TaxedCities dto)
    {
      var result = _services.Update(dto);
      if (result)
        return NoContent();
      else
        return NotFound();
    }

    //Return Tax Rule number from City name
    [HttpGet]
    [Route("GetTaxRule")]
    public ActionResult<int> GetTaxRule(int id)
    {
      var taxedCities = _services.GetTaxRule(id);

      return taxedCities;
    }


    [HttpGet("{id}", Name = "FindOne")]
    public ActionResult<TaxedCities> Get(int id)
    {
      var result = _services.FindOne(id);
      if (result != default)
        return _services.FindOne(id);
      else
        return NotFound();
    }
  }
}
