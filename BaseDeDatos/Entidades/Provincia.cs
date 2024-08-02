using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class Provincia
{
    public int ProvinciaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Localidad> Localidads { get; set; } = new List<Localidad>();
}
