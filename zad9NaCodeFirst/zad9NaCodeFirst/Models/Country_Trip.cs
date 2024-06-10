namespace zad9NaCodeFirst.Models;

public class Country_Trip
{
    public int IdCountry { get; set; }
    public int IdTrip { get; set; }
    public virtual Trip IdTripNavigation { get; set; }
    public Country IdCountryNavigation { get; set; }
}