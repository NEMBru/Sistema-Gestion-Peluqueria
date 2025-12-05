using System.Collections.Generic;
using DOM;

namespace APP
{
    public class appUsuario
    {
        public List<DOM.domUsuario> Traer()
        {
            List<DOM.domUsuario> lista = new List<DOM.domUsuario>();
            lista = REPO.repoUsuario.Traer();
            return lista;
        }

        public domUsuario Traer(int id)
        {
            return REPO.repoUsuario.Traer(id);
        }

        public void Agregar(DOM.domUsuario u)
        {
            u.Clave = SERV.Encriptar.CreateMD5(u.Clave);
            REPO.repoUsuario.Agregar(u);
        }

        public void Modificar(DOM.domUsuario u)
        {
            u.Clave = SERV.Encriptar.CreateMD5(u.Clave);
            REPO.repoUsuario.Modificar(u);
        }

        public void Eliminar(int id)
        {
            REPO.repoUsuario.Eliminar(id);
        }
    }
}