using Adesso.WorldLeague.Domain.Common;

namespace Adesso.WorldLeague.Domain.Entities;

public class Team : Entity
{
    public string Name { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; } = null!;
    
    public List<DrawGroupTeam> DrawGroupTeams { get; set; }
}