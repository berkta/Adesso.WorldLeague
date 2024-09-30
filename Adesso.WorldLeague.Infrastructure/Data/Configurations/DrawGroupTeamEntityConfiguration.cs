using Adesso.WorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adesso.WorldLeague.Infrastructure.Data.Configurations;

public class DrawGroupTeamEntityConfiguration : IEntityTypeConfiguration<DrawGroupTeam>
{
    public void Configure(EntityTypeBuilder<DrawGroupTeam> builder)
    {
        builder.HasKey(dgt => new { dgt.DrawId, dgt.GroupId, dgt.TeamId });

        builder.HasOne(dgt => dgt.Group)
            .WithMany(g => g.DrawGroupTeams)
            .HasForeignKey(dgt => dgt.GroupId);
        
        builder.HasOne(dgt => dgt.Draw)
            .WithMany(d => d.DrawGroupTeams)
            .HasForeignKey(dgt => dgt.DrawId);
        
        builder.HasOne(dgt => dgt.Team)
            .WithMany(t => t.DrawGroupTeams)
            .HasForeignKey(dgt => dgt.TeamId);
    }
}