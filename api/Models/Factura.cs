using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("facturas")]
public class Factura
{
    [Key, Column("id_factura")]
    public int IdFactura { get; set; }

    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("fecha")]
    public DateTime Fecha { get; set; }

    [Column("total")]
    public double Total { get; set; }

    public Cliente? Cliente { get; set; }
    public Empleado? Empleado { get; set; }
    public List<DetalleFactura> Detalles { get; set; } = new();
}
