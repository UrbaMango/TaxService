using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Services
{
    public class TaxRulesServices : ITaxRulesServices
    {
        private readonly Dictionary<string, TaxRules> _taxRules;

        public TaxRulesServices()
        {
            _taxRules = new Dictionary<string, TaxRules>();
        }
        public TaxRules AddTaxRules(TaxRules rules)
        {
           //insert check if exists
            _taxRules.Add(rules.TaxRuleNumber.ToString(), rules);
            return rules;
        }
        public Dictionary<string, TaxRules> GetTaxRules()
        {
            return _taxRules;
        }
        public double GetYearlyTaxRate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].YearlyTaxRate;
        }

        public double GetMonthlyTaxRate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].MonthlyTaxRate;
        }  

        public double GetWeeklyTaxRate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].WeeklyTaxRate;
        }
        public double GetDailyTaxRate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].DailyTaxRate;
        }
        public DateTime GetMonthlyTaxDate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].MonthlyTax;
        }
        public DateTime GetWeeklyTaxDate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].WeeklyTax;
        }

        public List<DateTime> GetDailyTaxDate(string taxRuleNumber)
        {
            return _taxRules[taxRuleNumber].DailyTax;
        }
    }
}
