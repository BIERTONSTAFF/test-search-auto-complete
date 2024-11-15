using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSearchAutoComplete.Models;

namespace TestSearchAutoComplete.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class NotesController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;
    private const string LANGUAGE = "russian";

    public NotesController(ApplicationDbContext ctx) => _ctx = ctx;

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Create([FromBody] Note note)
    {
        await _ctx.Notes.AddAsync(note);

        try
        {
            await _ctx.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

        return CreatedAtAction(nameof(Create), new { id = note.Id }, note);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Note>>> Search([FromQuery] string text)
    {
        if (String.IsNullOrEmpty(text))
            return new List<Note>();

        var res = await _ctx.Notes
            .Where(x => x.SearchVector!.Matches(EF.Functions.ToTsQuery(LANGUAGE, text)))
            .OrderByDescending(x => x.SearchVector!.Rank(EF.Functions.ToTsQuery(LANGUAGE, text)))
            .ToListAsync();

        return Ok(res);
    }
}
