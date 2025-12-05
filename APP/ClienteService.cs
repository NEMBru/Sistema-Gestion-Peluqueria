using DOM;
using ABS;
using REPO;
using System;
using System.Collections.Generic;

namespace APP
{
    public class ClienteService
    {
        private IClienteRepositorio repositorio;

        public ClienteService()
        {
            this.repositorio = new ClienteRepositorio();
        }

        public bool GuardarCliente(Cliente cliente)
        {
            try
            {
                repositorio.Guardar(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return repositorio.ObtenerTodos();
        }
    }
}