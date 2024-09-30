using Adesso.WorldLeague.Domain.Common;

namespace Adesso.WorldLeague.Domain.Entities;

public class Draw : Entity
{
    public string OperatorFirstName { get; set; }

    public string OperatorLastName { get; set; }
    
    public List<DrawGroupTeam> DrawGroupTeams { get; set; }
}