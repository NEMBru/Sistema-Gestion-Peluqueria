using ABS;
using DOM;
using CONTEXT;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace REPO
{
    public class ServicioRepositorio : IServicioRepositorio
    {
        public void Guardar(Servicio servicio)
        {
            var accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.AbrirConexion();
                string sql = "INSERT INTO Servicios (Nombre, Precio) VALUES (@Nombre, @Precio)";
                SqlCommand comando = accesoDatos.CrearComando(sql);

                comando.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                comando.Parameters.AddWithValue("@Precio", servicio.Precio);

                comando.ExecuteNonQuery();
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }

        public List<Servicio> ObtenerTodos()
        {
            var listaServicios = new List<Servicio>();
            var accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.AbrirConexion();
                string sql = "SELECT ServicioId, Nombre, Precio FROM Servicios";
                SqlCommand comando = accesoDatos.CrearComando(sql);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    var servicio = new Servicio
                    {
                        ServicioId = (int)lector["ServicioId"],
                        Nombre = lector["Nombre"].ToString(),
                        Precio = (decimal)lector["Precio"]
                    };
                    listaServicios.Add(servicio);
                }
                return listaServicios;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
    }
}