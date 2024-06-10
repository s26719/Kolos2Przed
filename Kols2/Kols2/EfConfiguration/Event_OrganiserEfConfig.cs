using Kols2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kols2.EfConfiguration;

public class Event_OrganiserEfConfig : IEntityTypeConfiguration<Event_Organiser>
{
    public void Configure(EntityTypeBuilder<Event_Organiser> builder)
    {
        builder.ToTable("Event_Organiser");
        builder.HasKey(eo => new { eo.IdEvent, eo.IdOrganiser });

        builder.Property(eo => eo.MainOrganiser).IsRequired();

        builder.HasOne(eo => eo.IdEventNavigation)
            .WithMany(e => e.EventOrganisers)
            .HasForeignKey(eo => eo.IdEvent);

        builder.HasOne(eo => eo.IdOrganiserNavigation)
            .WithMany(o => o.EventOrganisers)
            .HasForeignKey(eo => eo.IdOrganiser);

        builder.HasData(new List<Event_Organiser>()
        {
            new Event_Organiser()
            {
                IdEvent = 1,
                IdOrganiser = 1,
                MainOrganiser = true
            },
            new Event_Organiser()
            {
                IdEvent = 2,
                IdOrganiser = 2,
                MainOrganiser = false
            }
        });
    }
}