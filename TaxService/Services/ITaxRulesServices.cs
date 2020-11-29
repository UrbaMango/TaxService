using System;
using System.Collections.Generic;
using TaxService.Models;

namespace TaxService.Services
{
    public interface ITaxRulesServices
    {
        TaxRules AddTaxRules(TaxRules rules);
        IEnumerable<TaxRules> GetTaxRules();
        double GetYearlyTaxRate(int id);
        double GetMonthlyTaxRate(int id);
        double GetWeeklyTaxRate(int id);
        double GetDailyTaxRate(int id);
        DateTime GetMonthlyTaxDate(int id);
        DateTime GetWeeklyTaxDate(int id);
        List<DateTime> GetDailyTaxDate(int id);
    }
}
