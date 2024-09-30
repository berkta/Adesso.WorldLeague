using Adesso.WorldLeague.Application.Common;
using Adesso.WorldLeague.Application.Draws.Inputs;
using Adesso.WorldLeague.Application.Draws.Outputs;
using Adesso.WorldLeague.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Adesso.WorldLeague.Application.Draws.Commands;

public class CreateDrawCommand(CreateDrawCommandInput createDrawCommandInput) : IRequest<CreateDrawCommandOutput>
{
    public CreateDrawCommandInput CreateDrawCommandInput { get; } = createDrawCommandInput;
}

public class CreateDrawCommandHandler : IRequestHandler<CreateDrawCommand, CreateDrawCommandOutput>
{
    private readonly IApplicationDbContext _context;

    public CreateDrawCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateDrawCommandOutput> Handle(CreateDrawCommand request, CancellationToken cancellationToken)
    {
        var draw = new Draw()
        {
            OperatorFirstName = request.CreateDrawCommandInput.OperatorFirstName,
            OperatorLastName = request.CreateDrawCommandInput.OperatorLastName
        };
        
        await _context.Draws.AddAsync(draw);

        await _context.SaveChangesAsync(cancellationToken);
        
        var groups = await _context.Groups.Take(request.CreateDrawCommandInput.GroupCount).AsNoTracking().ToDictionaryAsync(
            g => g,
            g => new List<Team>()
            );

        var countriesWithTeams = await _context.Countries.Include(c => c.Teams).AsNoTracking().ToDictionaryAsync(
            c => c.Id,
            c => c.Teams);

        var random = new Random();
        
        foreach (var countryTeams in countriesWithTeams.Values)
        {
            countryTeams.Sort((t1, t2) => random.Next(-1, 2));
        }

        var groupIndex = 0;
        
        while (countriesWithTeams.Values.Any(teams => teams.Count > 0))
        {
            foreach (var countryId in countriesWithTeams.Keys)
            {
                var countryTeams = countriesWithTeams[countryId];
                
                if (countryTeams.Count > 0)
                {
                    var selectedGroup = groups.Keys.ToList()[groupIndex % request.CreateDrawCommandInput.GroupCount];
                    
                    if (!groups[selectedGroup].Any(t => t.CountryId == countryId))
                    {
                        var team = countryTeams[0];
                        groups[selectedGroup].Add(team);
                        countryTeams.RemoveAt(0);
                        groupIndex++;
                    }
                }
            }
        }

        foreach (var group in groups.Keys)
        {
            foreach (var team in groups[group])
            {
                await _context.DrawGroupTeams.AddAsync(new DrawGroupTeam()
                {
                    DrawId = draw.Id,
                    TeamId = team.Id,
                    GroupId = group.Id
                });
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        
        var groupDtos = groups.Select(g => new GroupDto
        {
            Name = g.Key.Name,
            Teams = g.Value.Select(t => new TeamDto
            {
                Name = t.Name
            }).ToList()
        }).ToList();
        
        return new CreateDrawCommandOutput()
        {
            Groups = groupDtos
        };
    }
}