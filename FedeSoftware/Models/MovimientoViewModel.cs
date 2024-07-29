namespace FedeSoftware.Models
{
    public class MovimientoViewModel
    {
        public int MovimientoId { get; set; }

        public int? ClienteProveedorId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Estado { get; set; }

        public virtual ClienteProveedorViewModel? ClienteProveedor { get; set; }

        public virtual ICollection<MovimientoDetViewModel> MovimientoDets { get; set; } = new List<MovimientoDetViewModel>();
    }
}
