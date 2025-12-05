using DOM;
using System.Collections.Generic;

namespace ABS
{
    public interface IServicioRepositorio
    {
        void Guardar(Servicio servicio);
        List<Servicio> ObtenerTodos();
    }
}