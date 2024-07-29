using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
