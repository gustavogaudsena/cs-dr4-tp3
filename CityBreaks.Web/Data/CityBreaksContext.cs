using CityBreaks.Web.Data.Configurations;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data;

public class CityBreaksContext : DbContext
{
    DbSet<Country> Countries { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Property> Properties { get; set; }

    public CityBreaksContext(DbContextOptions<CityBreaksContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyConfiguration());
    }
}