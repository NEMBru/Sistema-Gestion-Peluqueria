using System;
using System.Collections.Generic;

namespace DOM
{
    public abstract class ComponentePermiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual void AgregarHijo(ComponentePermiso c)
        {
            throw new NotImplementedException();
        }

        public virtual void QuitarHijo(ComponentePermiso c)
        {
            throw new NotImplementedException();
        }

        public virtual IList<ComponentePermiso> ObtenerHijos()
        {
            return new List<ComponentePermiso>();
        }
    }
}