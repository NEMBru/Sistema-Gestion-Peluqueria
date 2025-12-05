using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DOM;

namespace REPO
{
    public static class repoUsuario
    {
        static public void Agregar(DOM.domUsuario u)
        {
            CONTEXT.dalSQLServer sql = new CONTEXT.dalSQLServer();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuarios (Apellido, Nombre, Email, Rol, Estado, Clave, DV, Usuario_Agregar, Usaurio_modificar, Fecha_agregar, Fecha_Modificar) VALUES (@Apellido, @Nombre, @Email, @Rol, @Estado, @Clave, @DV, @Usuario_Agregar, @Usaurio_modificar, @Fecha_agregar, @Fecha_Modificar)";
            cmd.Connection = sql.AbrirConexion();

            cmd.Parameters.AddWithValue("@Apellido", u.Apellido);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            cmd.Parameters.AddWithValue("@Rol", u.Rol);
            cmd.Parameters.AddWithValue("@Estado", u.Estado);
            cmd.Parameters.AddWithValue("@Clave", u.Clave);
            cmd.Parameters.AddWithValue("@DV", "0");
            cmd.Parameters.AddWithValue("@Usuario_Agregar", 1);
            cmd.Parameters.AddWithValue("@Usaurio_modificar", 1);
            cmd.Parameters.AddWithValue("@Fecha_agregar", DateTime.Now);
            cmd.Parameters.AddWithValue("@Fecha_Modificar", DateTime.Now);

            sql.EjecutarNonQuery(cmd);
            sql.CerarConexion();
        }

        static public void Modificar(DOM.domUsuario u)
        {
            CONTEXT.dalSQLServer sql = new CONTEXT.dalSQLServer();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Usuarios SET Apellido = @Apellido, Nombre = @Nombre, Email = @Email, Rol = @Rol, Estado = @Estado, Clave = @Clave, Usaurio_modificar = @Usaurio_modificar, Fecha_Modificar = @Fecha_Modificar WHERE ID = @ID";
            cmd.Connection = sql.AbrirConexion();

            cmd.Parameters.AddWithValue("@ID", u.ID);
            cmd.Parameters.AddWithValue("@Apellido", u.Apellido);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            cmd.Parameters.AddWithValue("@Rol", u.Rol);
            cmd.Parameters.AddWithValue("@Estado", u.Estado);
            cmd.Parameters.AddWithValue("@Clave", u.Clave);
            cmd.Parameters.AddWithValue("@Usaurio_modificar", 1);
            cmd.Parameters.AddWithValue("@Fecha_Modificar", DateTime.Now);

            sql.EjecutarNonQuery(cmd);
            sql.CerarConexion();
        }

        static public void Eliminar(int id)
        {
            CONTEXT.dalSQLServer sql = new CONTEXT.dalSQLServer();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Usuarios WHERE ID = @ID";
            cmd.Connection = sql.AbrirConexion();
            cmd.Parameters.AddWithValue("@ID", id);
            sql.EjecutarNonQuery(cmd);
            sql.CerarConexion();
        }

        static public domUsuario Traer(int id)
        {
            DOM.domUsuario u = null;
            CONTEXT.dalSQLServer sql = new CONTEXT.dalSQLServer();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Usuarios WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Connection = sql.AbrirConexion();

            SqlDataReader dr = sql.EjecutarSQL(cmd);
            if (dr.Read())
            {
                u = CompletarObjeto(dr);
            }
            sql.CerarConexion();
            return u;
        }

        static public List<DOM.domUsuario> Traer()
        {
            List<DOM.domUsuario> lista = new List<DOM.domUsuario>();
            CONTEXT.dalSQLServer sql = new CONTEXT.dalSQLServer();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Usuarios";
            cmd.Connection = sql.AbrirConexion();
            lista = CompletarLista(sql.EjecutarSQL(cmd), lista);
            sql.CerarConexion();
            return lista;
        }

        static private domUsuario CompletarObjeto(SqlDataReader dr)
        {
            DOM.domUsuario u = new DOM.domUsuario();
            u.ID = Convert.ToInt32(dr["ID"]);
            u.Apellido = dr.IsDBNull(dr.GetOrdinal("Apellido")) ? "" : dr["Apellido"].ToString();
            u.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr["Nombre"].ToString();
            u.Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? "" : dr["Email"].ToString();
            u.Rol = Convert.ToInt32(dr["Rol"]);
            u.Estado = Convert.ToInt32(dr["Estado"]);
            u.Clave = dr.IsDBNull(dr.GetOrdinal("Clave")) ? "" : dr["Clave"].ToString();
            u.DV = dr.IsDBNull(dr.GetOrdinal("DV")) ? "" : dr["DV"].ToString();

            u.Usuario_Agregar = dr.IsDBNull(dr.GetOrdinal("Usuario_Agregar")) ? 0 : Convert.ToInt32(dr["Usuario_Agregar"]);
            u.Usuario_Modificar = dr.IsDBNull(dr.GetOrdinal("Usaurio_modificar")) ? 0 : Convert.ToInt32(dr["Usaurio_modificar"]);
            u.Fecha_Agregar = dr.IsDBNull(dr.GetOrdinal("Fecha_agregar")) ? DateTime.MinValue : Convert.ToDateTime(dr["Fecha_agregar"]);
            u.Fecha_Modificar = dr.IsDBNull(dr.GetOrdinal("Fecha_Modificar")) ? DateTime.MinValue : Convert.ToDateTime(dr["Fecha_Modificar"]);

            return u;
        }

        static private List<DOM.domUsuario> CompletarLista(SqlDataReader dr, List<DOM.domUsuario> lista)
        {
            while (dr.Read())
            {
                lista.Add(CompletarObjeto(dr));
            }
            return lista;
        }
    }
}