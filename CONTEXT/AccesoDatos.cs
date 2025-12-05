using System.Data.SqlClient;

namespace CONTEXT
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private string connectionString = "Server=localhost;Database=PeluqueriaDB;Trusted_Connection=True;";

        public void AbrirConexion()
        {
            conexion = new SqlConnection(connectionString);
            conexion.Open();
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

        public SqlCommand CrearComando(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, conexion);
            return comando;
        }
    }
}