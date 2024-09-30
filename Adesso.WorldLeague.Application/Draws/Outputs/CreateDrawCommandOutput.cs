namespace Adesso.WorldLeague.Application.Draws.Outputs;

public class CreateDrawCommandOutput
{
    public List<GroupDto> Groups { get; set; }
}

public class GroupDto()
{
    public char Name { get; set; }
    
    public List<TeamDto> Teams { get; set; }
}

public class TeamDto()
{
    public string Name { get; set; }
}