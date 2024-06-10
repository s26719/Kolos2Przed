namespace Kols2.DTO_s;

public class EventOutDto
{
    public int IdEvent { get; set; }
    public string Name { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<OrganiserOutDto> MainOrganisers { get; set; }
    public List<OrganiserOutDto> SubOrganisers { get; set; }
}