using Adesso.WorldLeague.Application.Common;
using Adesso.WorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adesso.WorldLeague.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Team> Teams { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Group> Groups { get; set; }
    
    public DbSet<Draw> Draws { get; set; }
    
    public DbSet<DrawGroupTeam> DrawGroupTeams { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}