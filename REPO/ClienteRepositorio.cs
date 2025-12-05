using ABS;
using DOM;
using CONTEXT;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace REPO
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public void Guardar(Cliente cliente)
        {
            var accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.AbrirConexion();
                string sql = "INSERT INTO Clientes (Nombre, Apellido, Telefono) VALUES (@Nombre, @Apellido, @Telefono)";
                SqlCommand comando = accesoDatos.CrearComando(sql);

                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                comando.ExecuteNonQuery();
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            var listaClientes = new List<Cliente>();
            var accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.AbrirConexion();
                string sql = "SELECT ClienteId, Nombre, Apellido, Telefono FROM Clientes";
                SqlCommand comando = accesoDatos.CrearComando(sql);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    var cliente = new Cliente
                    {
                        ClienteId = (int)lector["ClienteId"],
                        Nombre = lector["Nombre"].ToString(),
                        Apellido = lector["Apellido"].ToString(),
                        Telefono = lector["Telefono"].ToString()
                    };
                    listaClientes.Add(cliente);
                }
                return listaClientes;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
    }
}