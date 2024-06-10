using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.EfConfiguration;

public class Client_TripEfConfig : IEntityTypeConfiguration<Client_Trip>
{
    public void Configure(EntityTypeBuilder<Client_Trip> builder)
    {
        builder.ToTable("Client_Trip");
        builder.HasKey(ct => new { ct.IdClient, ct.IdTrip });
        builder.Property(ct => ct.RegisteredAt).IsRequired();
        builder.Property(ct => ct.PaymentDate).IsRequired(false);

        builder.HasOne(ct => ct.IdClientNavigation)
            .WithMany(c => c.ClientTrips)
            .HasForeignKey(ct => ct.IdClient);

        builder.HasOne(ct => ct.IdTripNavigation)
            .WithMany(t => t.ClientTrips)
            .HasForeignKey(ct => ct.IdTrip);
    }
}