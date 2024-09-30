using Adesso.WorldLeague.Domain.Common;

namespace Adesso.WorldLeague.Domain.Entities;

public class Country : Entity
{
    public string Name { get; set; }

    public List<Team> Teams { get; set; } = new List<Team>();
}