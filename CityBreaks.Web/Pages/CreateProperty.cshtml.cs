using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class CreateProperty : PageModel
{
    private readonly CityBreaksContext _context;
    [BindProperty]
    public Property Property { get; set; } = new();
    public SelectList CityList { get; set; } = default!;

    public CreateProperty(CityBreaksContext context)
    {
        _context = context;
    }


    public async Task OnGetAsync()
    {
        var cities = await _context.Cities
            .Include(c => c.Country)
            .ToListAsync();
        
        CityList = new SelectList(
            cities,
            nameof(City.Id),
            nameof(City.Name)
        );
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var cities = await _context.Cities
            .Include(c => c.Country)
            .ToListAsync();
        
        CityList = new SelectList(
            cities,
            nameof(City.Id),
            nameof(City.Name)
        );

        if (!ModelState.IsValid) return Page();

        await _context.Properties.AddAsync(Property);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}