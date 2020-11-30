using LiteDB;
using System;
using System.Collections.Generic;
using TaxService.LiteDB;
using TaxService.Models;
using System.Linq;

namespace TaxService.Services
{
  public class TaxRulesServices : ITaxRulesServices
  {
    private readonly Dictionary<int, TaxRules> _taxRules;
    private LiteDatabase _liteDb;

    public TaxRulesServices(ILiteDbContext liteDbContext)
        {
          _taxRules = new Dictionary<int, TaxRules>();
          _liteDb = liteDbContext.Database;
        }
    public TaxRules AddTaxRules(TaxRules rules)
        {
          //insert check if exists
          //_taxRules.Add(rules.TaxRuleNumber, rules);
          _liteDb.GetCollection<TaxRules>("TaxRules").Insert(rules);
          return rules;
        }
    public TaxRules EditTaxRule(TaxRules rules)
        {
            _liteDb.GetCollection<TaxRules>("TaxRules").Update(rules);
            return rules;
        }
    public bool DeleteTaxRule(int id)
        {
            return _liteDb.GetCollection<TaxedCities>("TaxedCities").Delete(id);
        }
    public TaxRules FindOne(int id)
        {
            return _liteDb.GetCollection<TaxRules>("TaxRules")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<TaxRules> GetTaxRules()
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules")
             .FindAll();
        }
    public double GetYearlyTaxRate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).YearlyTaxRate;
        }

    public double GetMonthlyTaxRate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).MonthlyTaxRate;
        }

    public double GetWeeklyTaxRate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).WeeklyTaxRate;
        }
    public double GetDailyTaxRate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).DailyTaxRate;
        }
    public DateTime GetMonthlyTaxDate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).MonthlyTax;
        }
    public DateTime GetWeeklyTaxDate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).WeeklyTax;
        }

    public List<DateTime> GetDailyTaxDate(int id)
        {
          return _liteDb.GetCollection<TaxRules>("TaxRules").FindById(id).DailyTax;
        }
  }
}
