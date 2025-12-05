using DOM;
using ABS;
using REPO;
using System;
using System.Diagnostics;

namespace APP
{
    public class UsuarioService
    {
        private IUsuarioRepositorio repositorio;

        public UsuarioService()
        {
            this.repositorio = new UsuarioRepositorio();
        }

        public bool GuardarUsuario(Usuario usuario)
        {
            try
            {
                repositorio.Guardar(usuario);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}