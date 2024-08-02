using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class Localidad
{
    public int LocalidadId { get; set; }

    public int ProvinciaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual Provincia Provincia { get; set; } = null!;
}
