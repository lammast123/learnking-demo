using LearnKing.Api.Data;
using LearnKing.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnKing.Api.Controllers;

public class TaskController : Controller
{
    private readonly AppDbContext _db;
    public TaskController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var items = await _db.Tasks.OrderBy(t => t.DueDate).ToListAsync();
        return View(items);
    }

    public IActionResult Create() => View(new TaskItem { DueDate = DateTime.UtcNow.AddDays(7) });

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem model)
    {
        if (!ModelState.IsValid) return View(model);
        model.CreatedAt = DateTime.UtcNow;
        _db.Tasks.Add(model);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _db.Tasks.FindAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TaskItem model)
    {
        if (!ModelState.IsValid) return View(model);
        _db.Tasks.Update(model);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.Tasks.FindAsync(id);
        if (item != null)
        {
            _db.Tasks.Remove(item);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}