namespace Adesso.WorldLeague.Domain.Entities;

public class DrawGroupTeam
{
    public int DrawId { get; set; }

    public Draw Draw { get; set; }
    
    public int GroupId { get; set; }
    
    public Group Group { get; set; }
    
    public int TeamId { get; set; }

    public Team Team { get; set; }
}