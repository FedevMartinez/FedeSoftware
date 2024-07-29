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


        public void Crear(ClienteProveedor clienteProveedor)
        {
            //validar etc
            var result = Repository.CreateAsync(clienteProveedor);

        }
        public IEnumerable<ClienteProveedor> Index()
        {
            //validar etc
            var result = Repository.ListAsync();

            return (IEnumerable<ClienteProveedor>)result;
        }

        public ClienteProveedor GetAsync(int id)
        {
            //validar etc
            var result = Repository.GetAsync(id);

            return result;
        }
    }
}
