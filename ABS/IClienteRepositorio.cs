using DOM;
using System.Collections.Generic;

namespace ABS
{
    public interface IClienteRepositorio
    {
        void Guardar(Cliente cliente);
        List<Cliente> ObtenerTodos();
    }
}