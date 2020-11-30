using LiteDB;

namespace TaxService.LiteDB
{
  public interface ILiteDbContext
  {
    LiteDatabase Database { get; }
  }
}
