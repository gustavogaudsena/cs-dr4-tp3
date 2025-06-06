using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICityService _cityService;
    public List<City> Cities { get; set; } = new List<City>();

    public IndexModel(ILogger<IndexModel> logger, ICityService cityService)
    {
        _logger = logger;
        _cityService = cityService;
    }
    public async void OnGetAsync()
    {
        Cities = await _cityService.GetAllAsync();

    }
}