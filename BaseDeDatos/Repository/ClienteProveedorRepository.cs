using BaseDeDatos.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BaseDeDatos.Entidades;

namespace BaseDeDatos.Repository
{
    public class ClienteProveedorRepository : RepositoryGeneric<ClienteProveedor>, IClienteProveedorRepository
    {
        private readonly FedeBaseContext _context;

        public ClienteProveedorRepository(FedeBaseContext context) : base(context)
        {
            _context = context;
        }

        public ClienteProveedor GetClienteProveedorByName(string nombre)
        {
            return new ClienteProveedor();
        }


        public IEnumerable<ClienteProveedor> Index()
        {
            IEnumerable<ClienteProveedor> ClienteProveedores = _context.ClienteProveedores.Include(x => x.ResponsabilidadFiscal).ToList();

            return ClienteProveedores;
        }

        public ClienteProveedor Get(int id)
        {
            var clienteProveedor = _context.ClienteProveedores.Include(x => x.ResponsabilidadFiscal).Where(x => x.ClienteProveedorId == id).FirstOrDefault();

            return clienteProveedor;
        }
    }
}
