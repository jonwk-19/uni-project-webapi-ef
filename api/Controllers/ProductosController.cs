using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductosController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Producto>>> GetAll()
    {
        return await _db.Productos.Include(p => p.Marca).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetById(int id)
    {
        var item = await _db.Productos.Include(p => p.Marca)
            .FirstOrDefaultAsync(p => p.IdProducto == id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> Create(Producto item)
    {
        item.IdProducto = 0;
        item.Marca = null;
        if (!await _db.Marcas.AnyAsync(m => m.IdMarca == item.IdMarca))
            return BadRequest("La marca no existe");

        _db.Productos.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.IdProducto }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Producto item)
    {
        if (!await _db.Productos.AnyAsync(p => p.IdProducto == id)) return NotFound();
        if (!await _db.Marcas.AnyAsync(m => m.IdMarca == item.IdMarca))
            return BadRequest("La marca no existe");

        item.IdProducto = id;
        item.Marca = null;
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
