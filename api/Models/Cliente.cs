using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("clientes")]
public class Cliente
{
    [Key, Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("nit"), Required, MaxLength(20)]
    public string Nit { get; set; } = "";

    [Column("nombre"), Required, MaxLength(100)]
    public string Nombre { get; set; } = "";

    [Column("apellidos"), Required, MaxLength(100)]
    public string Apellidos { get; set; } = "";

    [Column("email"), MaxLength(100)]
    public string? Email { get; set; }
}
