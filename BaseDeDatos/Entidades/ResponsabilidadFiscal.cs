using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class ResponsabilidadFiscal
{
    public int ResponsabilidadFiscalId { get; set; }

    public string? Descripcion { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<ClienteProveedor> ClienteProveedors { get; set; } = new List<ClienteProveedor>();
}
