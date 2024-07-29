using System;
using System.Collections.Generic;

namespace BaseDeDatos.Entidades;

public partial class ClienteProveedor
{
    public int ClienteProveedorId { get; set; }

    public string? RazonSocial { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Localidad { get; set; }

    public string? Whatsapp { get; set; }

    public string? Cuit { get; set; }

    public bool? EsCliente { get; set; }

    public bool? EsProveedor { get; set; }

    public int? ResponsabilidadFiscalId { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ResponsabilidadFiscal? ResponsabilidadFiscal { get; set; }
}
