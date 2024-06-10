using Microsoft.EntityFrameworkCore;
using zad9NaCodeFirst.EfConfiguration;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.Context;

public class MyDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Client_Trip> ClientTrips { get; set; }
    public DbSet<Country> Countries { get; set; }
    public Country_Trip CountryTrips { get; set; }
    public DbSet<Trip> Trips { get; set; }
    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEfConfig());
        modelBuilder.ApplyConfiguration(new CountryEfConfig());
        modelBuilder.ApplyConfiguration(new TripEfConfig());
        modelBuilder.ApplyConfiguration(new Country_TripEfConfig());
        modelBuilder.ApplyConfiguration(new Client_TripEfConfig());
    }
}