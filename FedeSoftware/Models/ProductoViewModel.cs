namespace FedeSoftware.Models
{
    public class ProductoViewModel
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

        public virtual CategoriaViewModel? Categoria { get; set; }

        public virtual ICollection<MovimientoDetViewModel> MovimientoDets { get; set; } = new List<MovimientoDetViewModel>();
    }
}
