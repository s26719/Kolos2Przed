namespace zad9NaCodeFirst.DTO_s;

public class TripOutDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }

    public List<CountryOutDto> Countries { get; set; }
    public List<ClientOutDto> Clients { get; set; }
}