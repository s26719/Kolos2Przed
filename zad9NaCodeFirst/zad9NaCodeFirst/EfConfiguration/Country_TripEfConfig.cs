using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.EfConfiguration;

public class Country_TripEfConfig : IEntityTypeConfiguration<Country_Trip>
{
    public void Configure(EntityTypeBuilder<Country_Trip> builder)
    {
        builder.ToTable("Country_Trip");
        builder.HasKey(ct => new { ct.IdCountry, ct.IdTrip });

        builder.HasOne(ct => ct.IdCountryNavigation)
            .WithMany(c => c.CountryTrips)
            .HasForeignKey(ct => ct.IdCountry);

        builder.HasOne(ct => ct.IdTripNavigation)
            .WithMany(t => t.CountryTrips)
            .HasForeignKey(ct => ct.IdTrip);
    }
}