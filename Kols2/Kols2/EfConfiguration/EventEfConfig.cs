using Kols2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kols2.EfConfiguration;

public class EventEfConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Event");
        builder.HasKey(e => e.IdEvent);
        builder.Property(e => e.IdEvent).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).HasMaxLength(60).IsRequired();
        builder.Property(e => e.DateFrom).IsRequired();
        builder.Property(e => e.DateTo).IsRequired(false);

        builder.HasMany(e => e.EventOrganisers)
            .WithOne(eo => eo.IdEventNavigation)
            .HasForeignKey(eo => eo.IdEvent)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Event>()
        {
            new Event()
            {
                IdEvent = 1,
                Name = "CLOUT",
                DateFrom = new DateTime(2024,6,20),
                DateTo = new DateTime(2024,6,25)
            },
            new Event()
            {
                IdEvent = 2,
                Name = "Event2",
                DateFrom = new DateTime(2024,10,20),
                DateTo = new DateTime(2024,10,25)
            }
        });
    }
}