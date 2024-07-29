namespace FedeSoftware.Models
{
    public class CategoriaViewModel
    {
        public int CategoriaId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public virtual ICollection<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();
    }
}
