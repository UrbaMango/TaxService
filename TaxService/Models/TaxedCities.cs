namespace TaxService.Models
{
  public class TaxedCities
  {
    public int Id { get; set; }
    public string Cityname { get; set; } //KEY
    public int TaxRule { get; set; }
  }
}
