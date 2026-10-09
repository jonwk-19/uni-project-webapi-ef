using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly AppDbContext _db;

    public MarcasController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Marca>>> GetAll()
    {
        return await _db.Marcas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marca>> GetById(int id)
    {
        var item = await _db.Marcas.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Marca>> Create(Marca item)
    {
        item.IdMarca = 0;
        _db.Marcas.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.IdMarca }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Marca item)
    {
        if (!await _db.Marcas.AnyAsync(x => x.IdMarca == id)) return NotFound();
        item.IdMarca = id;
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
