using Adesso.WorldLeague.Domain.Common;

namespace Adesso.WorldLeague.Domain.Entities;

public class Group : Entity
{
    public char Name { get; set; }
    
    public List<DrawGroupTeam> DrawGroupTeams { get; set; }
}