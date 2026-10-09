using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("empleados")]
public class Empleado
{
    [Key, Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("id_puesto")]
    public int IdPuesto { get; set; }

    [Column("nombre"), Required, MaxLength(100)]
    public string Nombre { get; set; } = "";

    [Column("apellidos"), Required, MaxLength(100)]
    public string Apellidos { get; set; } = "";

    [Column("fecha_contratacion", TypeName = "date")]
    public DateTime FechaContratacion { get; set; }

    public Puesto? Puesto { get; set; }
}
