using BaseDeDatos.Entidades;
using BaseDeDatos.Repository;

namespace FedeSoftware.Services
{
    public interface IClienteProveedorService 
    {
        void Create(ClienteProveedor clienteProveedor);
        IEnumerable<ClienteProveedor> Index();
        ClienteProveedor GetClienteProveedor(int id);
    }
}
