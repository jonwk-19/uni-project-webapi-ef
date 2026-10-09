using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("marcas")]
public class Marca
{
    [Key, Column("id_marca")]
    public int IdMarca { get; set; }

    [Column("nombre"), Required, MaxLength(50)]
    public string Nombre { get; set; } = "";
}
