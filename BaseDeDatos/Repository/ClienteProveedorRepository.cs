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
            
        }

        public ClienteProveedor GetClienteProveedorByName(string nombre)
        {
            return new ClienteProveedor();
        }


    }
}
