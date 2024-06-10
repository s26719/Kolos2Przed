using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.EfConfiguration;

public class CountryEfConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.HasKey(c => c.IdCountry);
        builder.Property(c => c.IdCountry).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(120).IsRequired();

        builder.HasMany(c => c.CountryTrips)
            .WithOne(ct => ct.IdCountryNavigation)
            .HasForeignKey(ct => ct.IdCountry)
            .OnDelete(DeleteBehavior.Cascade);

    }
}