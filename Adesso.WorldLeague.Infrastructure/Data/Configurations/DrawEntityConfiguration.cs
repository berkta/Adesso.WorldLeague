using Adesso.WorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adesso.WorldLeague.Infrastructure.Data.Configurations;

public class DrawEntityConfiguration : IEntityTypeConfiguration<Draw>
{
    public void Configure(EntityTypeBuilder<Draw> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).ValueGeneratedOnAdd();
    }
}