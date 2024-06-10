namespace Kols2.Models;

public class Event
{
    public int IdEvent { get; set; }
    public string Name { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime? DateTo { get; set; }

    public virtual ICollection<Event_Organiser> EventOrganisers { get; set; }
}