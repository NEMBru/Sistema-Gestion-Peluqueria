using System;

namespace DOM
{
    public class domUsuario
    {
        public int ID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public int Estado { get; set; }
        public string Clave { get; set; }
        public String DV { get; set; }
        public int Usuario_Agregar { get; set; }
        public int Usuario_Modificar { get; set; }
        public DateTime Fecha_Agregar { get; set; }
        public DateTime Fecha_Modificar { get; set; }
    }
}