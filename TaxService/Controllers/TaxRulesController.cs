using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaxService.Models;
using TaxService.Services;

namespace TaxService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaxRulesController : ControllerBase
    {
        private readonly ITaxRulesServices _services;

        public TaxRulesController(ITaxRulesServices services)
        {
            _services = services;
        }

        //Adding new tax rule: dates, rates
        [HttpPost]
        [Route("AddTaxRule")]
        public ActionResult<TaxRules> AddTaxRules(TaxRules rules)
        {
            var taxRules = _services.AddTaxRules(rules);
            if (taxRules == null)
            {
                return NotFound();
            }
            return taxRules;
        }

        //Parses out all of the TaxRules that we added
        [HttpGet]
        [Route("GetTaxRules")]
        public IEnumerable<TaxRules> Get()
        {
            return _services.GetTaxRules();
        }

    }
}