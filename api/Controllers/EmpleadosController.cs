using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly AppDbContext _db;

    public EmpleadosController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Empleado>>> GetAll()
    {
        return await _db.Empleados.Include(e => e.Puesto).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Empleado>> GetById(int id)
    {
        var item = await _db.Empleados.Include(e => e.Puesto)
            .FirstOrDefaultAsync(e => e.IdEmpleado == id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> Create(Empleado item)
    {
        item.IdEmpleado = 0;
        item.Puesto = null;
        if (!await _db.Puestos.AnyAsync(p => p.IdPuesto == item.IdPuesto))
            return BadRequest("El puesto no existe");

        _db.Empleados.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.IdEmpleado }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Empleado item)
    {
        if (!await _db.Empleados.AnyAsync(e => e.IdEmpleado == id)) return NotFound();
        if (!await _db.Puestos.AnyAsync(p => p.IdPuesto == item.IdPuesto))
            return BadRequest("El puesto no existe");

        item.IdEmpleado = id;
        item.Puesto = null;
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
