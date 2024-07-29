using BaseDeDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Repository
{
    public interface IClienteProveedorRepository : IRepositoryGeneric<ClienteProveedor>
    {
        ClienteProveedor GetClienteProveedorByName(string nombre);
    }
}
