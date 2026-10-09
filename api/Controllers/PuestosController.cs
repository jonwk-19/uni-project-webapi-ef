using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PuestosController : ControllerBase
{
    private readonly AppDbContext _db;

    public PuestosController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Puesto>>> GetAll()
    {
        return await _db.Puestos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Puesto>> GetById(int id)
    {
        var item = await _db.Puestos.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Puesto>> Create(Puesto item)
    {
        item.IdPuesto = 0;
        _db.Puestos.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.IdPuesto }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Puesto item)
    {
        if (!await _db.Puestos.AnyAsync(x => x.IdPuesto == id)) return NotFound();
        item.IdPuesto = id;
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
