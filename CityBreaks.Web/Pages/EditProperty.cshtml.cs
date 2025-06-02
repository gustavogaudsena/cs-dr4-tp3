using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class EditProperty : PageModel
{
    private readonly CityBreaksContext _context;
    [BindProperty] public Property Property { get; set; } = new();
    public SelectList CityList { get; set; } = default!;

    public EditProperty(CityBreaksContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Property = await _context.Properties.FindAsync(id);

        if (Property == null) return NotFound();

        var cities = await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        CityList = new SelectList(
            cities,
            nameof(City.Id),
            nameof(City.Name)
        );

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var propertyToUpdate = await _context.Properties.FindAsync(id);

        if (propertyToUpdate == null) return NotFound();

        if (await TryUpdateModelAsync<Property>(
                propertyToUpdate,
                "Property", 
                p => p.Name, p => p.PricePerNight, p => p.CityId))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
        
        var cities = await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        CityList = new SelectList(cities, "Id", "Name");

        return Page();
    }
}