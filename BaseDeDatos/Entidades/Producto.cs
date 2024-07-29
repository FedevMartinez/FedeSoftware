using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? PrecioDolar { get; set; }

    public decimal? PrecioPeso { get; set; }

    public int? StockActual { get; set; }

    public string? Observacion { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<MovimientoDet> MovimientoDets { get; set; } = new List<MovimientoDet>();
}
