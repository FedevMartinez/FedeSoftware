using BaseDeDatos.Entidades;
using BaseDeDatos.Repository;

namespace FedeSoftware.Services
{
    public interface IClienteProveedorService 
    {
        void Crear(ClienteProveedor clienteProveedor);
        IEnumerable<ClienteProveedor> Index();
        ClienteProveedor GetAsync(int id);
    }
}
