using System;
using System.Collections.Generic;

namespace DOM
{
    public class Patente : ComponentePermiso
    {
        public override void AgregarHijo(ComponentePermiso c)
        {
            throw new NotImplementedException("No se puede agregar un hijo a una patente.");
        }

        public override void QuitarHijo(ComponentePermiso c)
        {
            throw new NotImplementedException("No se puede quitar un hijo a una patente.");
        }

        public override IList<ComponentePermiso> ObtenerHijos()
        {
            return new List<ComponentePermiso>();
        }
    }
}