using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TaxService.Services
{
  public class CalculateServices : ICalculateServices
  {
    private readonly ITaxedCitiesServices _taxedcities;
    private readonly ITaxRulesServices _taxrules;

    private double yearlyTaxRate;

    private DateTime monthlyTaxDate;
    private double monthlyTaxRate;

    private DateTime weeklyTaxDate;
    private double weeklyTaxRate;

    private List<DateTime> dailyTaxDates;
    private double dailyTaxRate;

    public CalculateServices(ITaxedCitiesServices taxedcities, ITaxRulesServices taxrules)
    {
      _taxedcities = taxedcities;
      _taxrules = taxrules;
      //_logService =  logService

    }

    private void UpdateDateAndRates(int id)
    {
      yearlyTaxRate = _taxrules.GetYearlyTaxRate(id);

      monthlyTaxDate = _taxrules.GetMonthlyTaxDate(id);
      monthlyTaxRate = _taxrules.GetMonthlyTaxRate(id);

      weeklyTaxDate = _taxrules.GetWeeklyTaxDate(id);
      weeklyTaxRate = _taxrules.GetWeeklyTaxRate(id);

      dailyTaxDates = _taxrules.GetDailyTaxDate(id);
      dailyTaxRate = _taxrules.GetDailyTaxRate(id);
    }
    public double CalculateTax(int id, DateTime date)
    {
      UpdateDateAndRates(id);

      if (date.Year == 2020)
      {
        switch (id)
        {
          case 1:
            return RuleOneCalculation(date);
          case 2:
            return RuleTwoCalculation(date);
          default:
            throw new DataException("Such rule has not been found");
        }
      }
      else
        throw new DataException("It has to be year 2020, that's why it's called 2020 Tax Calculator");

    }

    private double RuleOneCalculation(DateTime date)
    {
      List<double> rate = new List<double>();

      rate.Add(yearlyTaxRate);

      if (date.Month == monthlyTaxDate.Month)
      {
        rate.Add(monthlyTaxRate);
      }

      for (int i = 0; i < 6; i++)
      {
        if (date.Date == weeklyTaxDate.Date)
          rate.Add(weeklyTaxRate);
        weeklyTaxDate = weeklyTaxDate.AddDays(1);
      }

      if (dailyTaxDates != null)
      {
        foreach (DateTime dat in dailyTaxDates)
        {
          if (date.Date == dat.Date)
            rate.Add(dailyTaxRate);
        }
      }

      return rate.Sum();
    }
    private double RuleTwoCalculation(DateTime date)
    {
      if (dailyTaxDates != null)
      {
        foreach (DateTime dat in dailyTaxDates)
        {
          if (date.Date == dat.Date)
            return dailyTaxRate;
        }
      }

      for (int i = 0; i < 6; i++)
      {
        if (date.Date == weeklyTaxDate.Date)
          return weeklyTaxRate;
        weeklyTaxDate = weeklyTaxDate.AddDays(1);
      }

      if (date.Month == monthlyTaxDate.Month)
        return monthlyTaxRate;

      return yearlyTaxRate;
    }
  }
}
