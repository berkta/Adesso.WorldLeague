using Adesso.WorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.WorldLeague.Infrastructure.Data;

public static class ApplicationSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        using var transaction = context.Database.BeginTransaction();

        try
        {
            if (!await context.Teams.AnyAsync())
            {
                Dictionary<string, string[]> countryTeams = new Dictionary<string, string[]>
                {
                    { "Türkiye", [ "Adesso İstanbul", "Adesso Ankara", "Adesso İzmir", "Adesso Antalya"] },
                    { "Almanya", [ "Adesso Berlin", "Adesso Frankfurt", "Adesso Münih", "Adesso Dortmund"] },
                    { "Fransa", [ "Adesso Paris", "Adesso Marsilya", "Adesso Nice", "Adesso Lyon"] },
                    { "Hollanda", [ "Adesso Amsterdam", "Adesso Rotterdam", "Adesso Lahey", "Adesso Eindhoven" ] },
                    { "Portekiz", [ "Adesso Lisbon", "Adesso Porto", "Adesso Braga", "Adesso Coimbra" ] },
                    { "İtalya", [ "Adesso Roma", "Adesso Milano", "Adesso Venedik", "Adesso Napoli" ] },
                    { "İspanya", [ "Adesso Sevilla", "Adesso Madrid", "Adesso Barselona", "Adesso Granada" ] },
                    { "Belçika", [ "Adesso Brüksel", "Adesso Brugge", "Adesso Gent", "Adesso Anvers" ] }
                };
        
                List<char> groupNames = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
        
                List<Country> countries = new List<Country>();
        
                foreach (var countryName in countryTeams.Keys) 
                {
                    countries.Add(new Country()
                    {
                        Name = countryName
                    });
                }
        
                await context.Countries.AddRangeAsync(countries);
                await context.SaveChangesAsync();
        
                var dbCountries = await context.Countries.ToListAsync();
        
                foreach (var dbCountry in dbCountries)
                {
                    var teamNames = countryTeams[dbCountry.Name];
                    foreach (var teamName in teamNames)
                    {
                        await context.Teams.AddAsync(new Team()
                        {
                            Name = teamName,
                            CountryId = dbCountry.Id
                        });
                    }
                }
        
                foreach (var groupName in groupNames)
                {
                    await context.Groups.AddAsync(new Group()
                    {
                        Name = groupName
                    });
                }
        
                await context.SaveChangesAsync();
                
                transaction.Commit();
            }
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}