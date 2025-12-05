using System.Collections.Generic;

namespace DOM
{
    public class Familia : ComponentePermiso
    {
        private List<ComponentePermiso> _hijos;

        public Familia()
        {
            _hijos = new List<ComponentePermiso>();
        }

        public override void AgregarHijo(ComponentePermiso c)
        {
            _hijos.Add(c);
        }

        public override void QuitarHijo(ComponentePermiso c)
        {
            _hijos.Remove(c);
        }

        public override IList<ComponentePermiso> ObtenerHijos()
        {
            return _hijos;
        }
    }
}