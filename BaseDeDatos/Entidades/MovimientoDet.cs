using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class MovimientoDet
{
    public int MovimientoDetId { get; set; }

    public int? MovimientoId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public string? Observacion { get; set; }

    public virtual Movimiento? Movimiento { get; set; }

    public virtual Producto? Producto { get; set; }
}
