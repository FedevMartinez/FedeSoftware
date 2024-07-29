namespace FedeSoftware.Models
{
    public class ResponsabilidadFiscalViewModel
    {
        public int ResponsabilidadFiscalId { get; set; }

        public string? Descripcion { get; set; }

        public virtual ICollection<ClienteProveedorViewModel> ClienteProveedors { get; set; } = new List<ClienteProveedorViewModel>();
    }
}
