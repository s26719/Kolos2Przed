using Kols2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kols2.EfConfiguration;

public class OrganiserEfConfig : IEntityTypeConfiguration<Organiser>
{
    public void Configure(EntityTypeBuilder<Organiser> builder)
    {
        builder.ToTable("Organiser");
        builder.HasKey(o => o.IdOrganiser);
        builder.Property(o => o.IdOrganiser).ValueGeneratedOnAdd();

        builder.Property(o => o.Name).HasMaxLength(50).IsRequired();

        builder.HasMany(o => o.EventOrganisers)
            .WithOne(eo => eo.IdOrganiserNavigation)
            .HasForeignKey(eo => eo.IdOrganiser)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Organiser>()
        {
            new Organiser()
            {
                IdOrganiser = 1,
                Name = "admin1"
            },
            new Organiser()
            {
                IdOrganiser = 2,
                Name = "admin2"
            }
        });
    }
}