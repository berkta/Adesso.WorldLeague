using Adesso.WorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adesso.WorldLeague.Application.Common;

public interface IApplicationDbContext
{ 
    public DbSet<Team> Teams { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Group> Groups { get; set; }
    
    public DbSet<Draw> Draws { get; set; }
    
    public DbSet<DrawGroupTeam> DrawGroupTeams { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}