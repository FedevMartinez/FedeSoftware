using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class Movimiento
{
    public int MovimientoId { get; set; }

    public int? ClienteProveedorId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public virtual ClienteProveedor? ClienteProveedor { get; set; }

    public virtual ICollection<MovimientoDet> MovimientoDets { get; set; } = new List<MovimientoDet>();
}
