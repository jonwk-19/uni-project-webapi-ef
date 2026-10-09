using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("detalle_facturas")]
public class DetalleFactura
{
    [Key, Column("id_detalle")]
    public int IdDetalle { get; set; }

    [Column("id_factura")]
    public int IdFactura { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_unitario")]
    public double PrecioUnitario { get; set; }

    [Column("subtotal")]
    public double Subtotal { get; set; }
}
