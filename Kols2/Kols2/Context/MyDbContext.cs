using Kols2.EfConfiguration;
using Kols2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kols2.Context;

public class MyDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Event_Organiser> EventOrganisers { get; set; }
    public DbSet<Organiser> Organisers { get; set; }
    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Event_OrganiserEfConfig());
        modelBuilder.ApplyConfiguration(new OrganiserEfConfig());
        modelBuilder.ApplyConfiguration(new EventEfConfig());
    }
}