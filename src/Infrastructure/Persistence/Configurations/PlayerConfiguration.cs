using ArcadiaStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadiaStats.Infrastructure.Persistence.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(150)
                .IsRequired();

        }
    }
}