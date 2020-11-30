using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxService.LiteDB;
using TaxService.Models;

namespace TaxService.Services
{
  public class TaxedCitiesServices : ITaxedCitiesServices
  {
    //private readonly Dictionary<string, TaxedCities> _taxedCities;//delete later
    private LiteDatabase _liteDb;

    public TaxedCitiesServices(ILiteDbContext liteDbContext)
    {

      _liteDb = liteDbContext.Database;
    }

    public IEnumerable<TaxedCities> FindAll()
    {
      return _liteDb.GetCollection<TaxedCities>("TaxedCities")
          .FindAll();
    }

    public int Delete(int id)
    {
      //return _liteDb.GetCollection<TaxedCities>("TaxedCities")
      //.Delete(x => x.Id == id);
      throw new NotImplementedException();
    }

    public bool Update(TaxedCities forecast)
    {
      return _liteDb.GetCollection<TaxedCities>("TaxedCities")
          .Update(forecast);
    }

    public TaxedCities AddTaxedCities(TaxedCities cities)
    {

      _liteDb.GetCollection<TaxedCities>("TaxedCities").Insert(cities);

      return cities;
    }
    public int GetTaxRule(int id)
    {
      return _liteDb.GetCollection<TaxedCities>("TaxedCities")
          .Find(x => x.Id == id).FirstOrDefault().TaxRule;
    }

    public TaxedCities FindOne(int id)
    {
      return _liteDb.GetCollection<TaxedCities>("TaxedCities")
          .Find(x => x.Id == id).FirstOrDefault();
    }

  }
}
