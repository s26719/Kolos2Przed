namespace Kols2.Models;

public class Organiser
{
    public int IdOrganiser { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Event_Organiser> EventOrganisers { get; set; }
}