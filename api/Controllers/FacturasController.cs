using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturasController : ControllerBase
{
    private readonly AppDbContext _db;

    public FacturasController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Factura>>> GetAll()
    {
        return await _db.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Empleado)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Factura>> GetById(int id)
    {
        var item = await _db.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Empleado)
            .Include(f => f.Detalles)
            .FirstOrDefaultAsync(f => f.IdFactura == id);
        if (item == null) return NotFound();
        return item;
    }

    // Crea la factura junto con su detalle; subtotales y total se calculan aqui
    [HttpPost]
    public async Task<ActionResult<Factura>> Create(Factura item)
    {
        if (item.Detalles.Count == 0) return BadRequest("La factura necesita al menos un detalle");
        if (!await _db.Clientes.AnyAsync(c => c.IdCliente == item.IdCliente))
            return BadRequest("El cliente no existe");
        if (!await _db.Empleados.AnyAsync(e => e.IdEmpleado == item.IdEmpleado))
            return BadRequest("El empleado no existe");

        item.IdFactura = 0;
        item.Cliente = null;
        item.Empleado = null;
        if (item.Fecha == default) item.Fecha = DateTime.Now;

        foreach (var d in item.Detalles)
        {
            var producto = await _db.Productos.FindAsync(d.IdProducto);
            if (producto == null) return BadRequest($"El producto {d.IdProducto} no existe");
            if (d.Cantidad <= 0) return BadRequest("La cantidad debe ser mayor a 0");
            if (producto.Stock < d.Cantidad) return BadRequest($"Stock insuficiente de {producto.Nombre}");

            d.IdDetalle = 0;
            d.PrecioUnitario = producto.Precio;
            d.Subtotal = d.Cantidad * d.PrecioUnitario;
            producto.Stock -= d.Cantidad;
        }
        item.Total = item.Detalles.Sum(d => d.Subtotal);

        _db.Facturas.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.IdFactura }, item);
    }

    // Solo actualiza la cabecera (cliente, empleado, fecha)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Factura item)
    {
        var factura = await _db.Facturas.FindAsync(id);
        if (factura == null) return NotFound();
        if (!await _db.Clientes.AnyAsync(c => c.IdCliente == item.IdCliente))
            return BadRequest("El cliente no existe");
        if (!await _db.Empleados.AnyAsync(e => e.IdEmpleado == item.IdEmpleado))
            return BadRequest("El empleado no existe");

        factura.IdCliente = item.IdCliente;
        factura.IdEmpleado = item.IdEmpleado;
        factura.Fecha = item.Fecha;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
