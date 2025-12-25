using Microsoft.AspNetCore.Mvc;
using AnimeSite.Models;

namespace AnimeSite.Controllers;

public class CommentController : Controller
{
    private readonly AppDbContext _context;

    public CommentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(Comment comment)
    {
        comment.CreatedDate = DateTime.Now;

        _context.Comments.Add(comment);
        _context.SaveChanges();

        return RedirectToAction("Details", "Anime", new { id = comment.AnimeId });
    }
    public IActionResult Delete(int id)
    {
        var comment = _context.Comments.Find(id);
        var animeId = comment.AnimeId;

        _context.Comments.Remove(comment);
        _context.SaveChanges();

        return RedirectToAction("Details", "Anime", new { id = animeId });
    }
    public IActionResult Edit(int id)
    {
        var comment = _context.Comments.Find(id);
        return View(comment);
    }
    [HttpPost]
    public IActionResult Edit(Comment comment)
    {
        _context.Comments.Update(comment);
        _context.SaveChanges();

        return RedirectToAction("Details", "Anime", new { id = comment.AnimeId });
    }


}
