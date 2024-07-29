namespace FedeSoftware.Models
{
    public class MovimientoDetViewModel
    {
        public int MovimientoDetId { get; set; }

        public int? MovimientoId { get; set; }

        public int? ProductoId { get; set; }

        public int? Cantidad { get; set; }

        public string? Observacion { get; set; }

        public virtual MovimientoViewModel? Movimiento { get; set; }

        public virtual ProductoViewModel? Producto { get; set; }
    }
}
