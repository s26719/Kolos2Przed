using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.EfConfiguration;

public class TripEfConfig : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable("Trip");
        builder.HasKey(t => t.IdTrip);
        builder.Property(t => t.IdTrip).ValueGeneratedOnAdd();

        builder.Property(t => t.Name).HasMaxLength(120).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(220).IsRequired();
        builder.Property(t => t.DateFrom).IsRequired();
        builder.Property(t => t.DateTo).IsRequired();
        builder.Property(t => t.MaxPeople).IsRequired();

        builder.HasMany(t => t.ClientTrips)
            .WithOne(ct => ct.IdTripNavigation)
            .HasForeignKey(ct => ct.IdTrip)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.CountryTrips)
            .WithOne(ct => ct.IdTripNavigation)
            .HasForeignKey(ct => ct.IdTrip)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}