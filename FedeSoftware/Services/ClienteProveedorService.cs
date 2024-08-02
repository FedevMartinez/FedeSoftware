using BaseDeDatos.Entidades;
using BaseDeDatos.Repository;

namespace FedeSoftware.Services
{
    public class ClienteProveedorService : IClienteProveedorService
    {

        private IClienteProveedorRepository Repository;

        public ClienteProveedorService(IClienteProveedorRepository repository)
        {
            Repository = repository;
        }


        public void Create(ClienteProveedor clienteProveedor)
        {
            //validar etc
            if (clienteProveedor.Nombre != "")
            {
                var result = Repository.CreateAsync(clienteProveedor);
            }


        }
        public IEnumerable<ClienteProveedor> Index()
        {
            // Agregar validacion si es cliente, proveedor, o ambas
            var result = Repository.Index();

            return result;
        }

        public ClienteProveedor GetClienteProveedor(int id)
        {
            var result = Repository.Get(id);

            return result;
        }
    }
}
