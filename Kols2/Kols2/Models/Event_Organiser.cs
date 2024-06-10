namespace Kols2.Models;

public class Event_Organiser
{
    public int IdEvent { get; set; }
    public int IdOrganiser { get; set; }
    public bool MainOrganiser { get; set; }

    public virtual Event IdEventNavigation { get; set; }
    public virtual Organiser IdOrganiserNavigation { get; set; }
}