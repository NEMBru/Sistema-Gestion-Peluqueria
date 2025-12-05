using DOM;
using ABS;
using REPO;
using System;
using System.Collections.Generic;

namespace APP
{
    public class ServicioService
    {
        private IServicioRepositorio repositorio;

        public ServicioService()
        {
            this.repositorio = new ServicioRepositorio();
        }

        public bool GuardarServicio(Servicio servicio)
        {
            try
            {
                repositorio.Guardar(servicio);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Servicio> ObtenerTodosLosServicios()
        {
            return repositorio.ObtenerTodos();
        }
    }
}