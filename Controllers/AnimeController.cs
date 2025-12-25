using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeSite.Models;

namespace AnimeSite.Controllers;

public class AnimeController : Controller
{
    private readonly AppDbContext _context;

    public AnimeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Details(int id)
    {
        var anime = _context.Animes
            .Include(a => a.Comments)
            .FirstOrDefault(a => a.Id == id);

        return View(anime);
    }
}
