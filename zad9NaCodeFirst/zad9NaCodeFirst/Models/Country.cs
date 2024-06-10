namespace zad9NaCodeFirst.Models;

public class Country
{
    public int IdCountry { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Country_Trip> CountryTrips { get; set; }
}