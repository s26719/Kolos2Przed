using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.EfConfiguration;

public class ClientEfConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");
        builder.HasKey(c => c.IdClient);
        builder.Property(c => c.IdClient).ValueGeneratedOnAdd();

        builder.Property(c => c.FirstName).HasMaxLength(120).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(120).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(120).IsRequired();
        builder.Property(c => c.Telephone).HasMaxLength(120).IsRequired();
        builder.Property(c => c.Pesel).HasMaxLength(120).IsRequired();

        builder.HasMany(c => c.ClientTrips)
            .WithOne(ct => ct.IdClientNavigation)
            .HasForeignKey(ct => ct.IdClient)
            .OnDelete(DeleteBehavior.Cascade);
    }
}