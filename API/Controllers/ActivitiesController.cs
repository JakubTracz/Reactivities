using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseController
{
    private readonly DataContext _context;

    public ActivitiesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities() => await _context.Activities.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivities(Guid id)
    {
        var result = await _context.Activities.FindAsync(id);

        if (result is null)
            return NotFound(id);

        return result;
    }
}