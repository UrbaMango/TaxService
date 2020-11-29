using System;
using System.Collections.Generic;

namespace TaxService.Models
{
    public class TaxRules
    {
        public int Id { get; set; }
        public int TaxRuleNumber { get; set; } 
        public double YearlyTaxRate { get; set; } //2020.01.01-2020-12.31 always, does not change between rules
        public DateTime MonthlyTax { get; set; } //Certain month, only month changes. e.g. 2020.05.01-2020.05.31
        public double MonthlyTaxRate { get; set; }
        public DateTime WeeklyTax { get; set; } //7(plus 6 days from given date) days from given date e.g. 2020.01.06-2020.01.12
        public double WeeklyTaxRate { get; set; }
        public List<DateTime> DailyTax { get; set; } //Certain days that are taxed, can be multiple days. e.g. 2020.01.01;2020.12.25
        public double DailyTaxRate { get; set; }
    }
}
