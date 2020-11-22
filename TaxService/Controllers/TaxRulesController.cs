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
    public class TaxRulesController : ControllerBase
    {
        private readonly ITaxRulesServices _services;

        public TaxRulesController(ITaxRulesServices services)
        {
            _services = services;
        }

        //Adding new tax rule: dates, rates
        [HttpPost]
        [Route("AddTaxRules")]
        public ActionResult<TaxRules> AddTaxRules (TaxRules rules)
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
        public ActionResult<Dictionary<string, TaxRules>> GetTaxRules()
        {
            var taxRules = _services.GetTaxRules();

            if (taxRules.Count == 0)
            {
                return NotFound();
            }
            return taxRules;
        }
    }
}