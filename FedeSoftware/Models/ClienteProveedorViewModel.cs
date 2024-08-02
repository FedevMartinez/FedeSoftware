using BaseDeDatos.Entidades;

namespace FedeSoftware.Models
{
    public class ClienteProveedorViewModel
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

        //public virtual ICollection<MovimientoViewModel> Movimientos { get; set; } = new List<MovimientoViewModel>();

        //public virtual ResponsabilidadFiscalViewModel? ResponsabilidadFiscal { get; set; }

        public ClienteProveedorViewModel()
        {
                
        }

        public ClienteProveedor ToEntity()
        {
            var clienteProveedor = new ClienteProveedor
            {
                RazonSocial = RazonSocial,
                Nombre = Nombre,
                Apellido = Apellido,
                Direccion = Direccion,
                Localidad = Localidad,
                Whatsapp = Whatsapp,
                Cuit = Cuit,
                ResponsabilidadFiscalId = ResponsabilidadFiscalId,
                EsCliente = EsCliente,
                EsProveedor = EsProveedor
            };
            return clienteProveedor;
        }
    }
}
