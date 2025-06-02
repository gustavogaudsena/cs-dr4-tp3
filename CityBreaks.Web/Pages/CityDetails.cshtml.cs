using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class CityDetails : PageModel
{
    
    private readonly ICityService _cityService;
    public City? City { get; set; }

    public CityDetails(ICityService cityService)
    {
        _cityService = cityService;
    }
    
    public async void OnGetAsync(string name)
    {
        City = await _cityService.GetByNameAsync(name);
    }
}