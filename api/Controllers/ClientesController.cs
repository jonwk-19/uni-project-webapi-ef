using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _db;

    public ClientesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> GetAll()
    {
        return await _db.Clientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var item = await _db.Clientes.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente item)
    {
        item.IdCliente = 0;
        _db.Clientes.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.IdCliente }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente item)
    {
        if (!await _db.Clientes.AnyAsync(x => x.IdCliente == id)) return NotFound();
        item.IdCliente = id;
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
