using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Services
{
    public interface ITaxRulesServices
    {
        TaxRules AddTaxRules(TaxRules rules);
        Dictionary<string, TaxRules> GetTaxRules();
        double GetYearlyTaxRate(string taxRuleNumber);
        double GetMonthlyTaxRate(string taxRuleNumber);
        double GetWeeklyTaxRate(string taxRuleNumber);
        double GetDailyTaxRate(string taxRuleNumber);
        DateTime GetMonthlyTaxDate(string taxRuleNumber);
        DateTime GetWeeklyTaxDate(string taxRuleNumber);
        List <DateTime> GetDailyTaxDate(string taxRuleNumber);
    }
}
