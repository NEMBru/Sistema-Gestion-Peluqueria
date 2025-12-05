using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CONTEXT
{
    public class dalSQLServer
    {
        private SqlConnection con;
        public dalSQLServer()
        {
            con = new SqlConnection();
        }
        private string StringConexion()
        {
           
            return "Server=.;Database=Peluqueria System;Integrated Security=True";
        }
        public SqlConnection AbrirConexion()
        {
            con.ConnectionString = StringConexion();
            con.Open();
            return con;
        }
        public void CerarConexion()
        {
            con.Close();
        }
        public void AbrirTransaccion() { }
        public void CerrarTransaccion() { }
        private void CancelarTransaccion() { }
        public SqlDataReader EjecutarSQL(SqlCommand cmd)
        {
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }

        public int EjecutarNonQuery(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }
    }
}