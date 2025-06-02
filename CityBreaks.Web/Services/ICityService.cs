using CityBreaks.Web.Models;

namespace CityBreaks.Web.Services;

public interface ICityService
{
    public Task<List<City>> GetAllAsync();
    public Task<City?> GetByNameAsync(string name);
}