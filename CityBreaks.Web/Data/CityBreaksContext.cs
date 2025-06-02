using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data;

public class CityBreaksContext: DbContext
{
    DbSet<Country> Countries { get; set; }
}