using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("productos")]
public class Producto
{
    [Key, Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("id_marca")]
    public int IdMarca { get; set; }

    [Column("nombre"), Required, MaxLength(100)]
    public string Nombre { get; set; } = "";

    [Column("precio")]
    public double Precio { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    public Marca? Marca { get; set; }
}
