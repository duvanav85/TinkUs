using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Data.Entities;

[PrimaryKey("Id", "Identificacion")]
[Table("tbl_Employees")]
public partial class TblEmployee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Key]
    public long Identificacion { get; set; }

    [StringLength(255)]
    public string Nombre { get; set; } = null!;

    public int? Posicion { get; set; }

    [StringLength(150)]
    public string? Descripcion { get; set; }

    public byte? Estado { get; set; }
}
