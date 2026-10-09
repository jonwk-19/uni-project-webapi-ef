using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("puestos")]
public class Puesto
{
    [Key, Column("id_puesto")]
    public int IdPuesto { get; set; }

    [Column("nombre"), Required, MaxLength(50)]
    public string Nombre { get; set; } = "";

    [Column("salario_base")]
    public double SalarioBase { get; set; }
}
