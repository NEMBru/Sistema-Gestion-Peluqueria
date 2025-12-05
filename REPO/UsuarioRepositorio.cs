using ABS;
using DOM;
using CONTEXT;
using System.Data.SqlClient;

namespace REPO
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void Guardar(Usuario usuario)
        {
            var accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.AbrirConexion();
                string sql = "INSERT INTO Usuarios (Nombre, Apellido, Email, Clave, Estado) VALUES (@Nombre, @Apellido, @Email, @Clave, @Estado)";
                SqlCommand comando = accesoDatos.CrearComando(sql);

                comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@Email", usuario.Email);
                comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                comando.Parameters.AddWithValue("@Estado", usuario.Estado);

                comando.ExecuteNonQuery();
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
    }
}