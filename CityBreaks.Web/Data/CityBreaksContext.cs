using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data;

public class CityBreaksContext: DbContext
{
    DbSet<Country> Countries { get; set; }
    
    public CityBreaksContext(DbContextOptions<CityBreaksContext> options)
        : base(options)
    {
    }
}