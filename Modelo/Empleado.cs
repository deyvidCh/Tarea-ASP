using System;
using System.Data;
using MySql.Data.MySqlClient;
using vista;

namespace Modelo
{
    public class Empleado
    {
        private ConexionBD conectar;
        public DataTable ObtenerPuestos()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = "SELECT id_puesto AS id, puesto FROM puestos;";
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public DataTable ObtenerEmpleados()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();

            string consulta = "SELECT e.id_empleado AS id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefono, e.fecha_nacimiento, p.puesto, p.id_puesto " +
                              "FROM empleados AS e " +
                              "INNER JOIN puestos AS p ON e.id_puesto = p.id_puesto " +
                              "ORDER BY e.codigo;"; 

            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }


        public int AgregarEmpleado(string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int resultado = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = "INSERT INTO empleados(codigo, nombres, apellidos, direccion, telefono, fecha_nacimiento, id_puesto) VALUES(@codigo, @nombres, @apellidos, @direccion, @telefono, @fecha, @id_puesto)";
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Parameters.AddWithValue("@codigo", codigo);
            insertar.Parameters.AddWithValue("@nombres", nombres);
            insertar.Parameters.AddWithValue("@apellidos", apellidos);
            insertar.Parameters.AddWithValue("@direccion", direccion);
            insertar.Parameters.AddWithValue("@telefono", telefono);
            insertar.Parameters.AddWithValue("@fecha", fecha);
            insertar.Parameters.AddWithValue("@id_puesto", id_puesto);

            resultado = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return resultado;
        }
        public int ModificarEmpleado(int id, string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int resultado = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = "UPDATE empleados SET codigo = @codigo, nombres = @nombres, apellidos = @apellidos, direccion = @direccion, telefono = @telefono, fecha_nacimiento = @fecha, id_puesto = @id_puesto WHERE id_empleado = @id";
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Parameters.AddWithValue("@id", id);
            modificar.Parameters.AddWithValue("@codigo", codigo);
            modificar.Parameters.AddWithValue("@nombres", nombres);
            modificar.Parameters.AddWithValue("@apellidos", apellidos);
            modificar.Parameters.AddWithValue("@direccion", direccion);
            modificar.Parameters.AddWithValue("@telefono", telefono);
            modificar.Parameters.AddWithValue("@fecha", fecha);
            modificar.Parameters.AddWithValue("@id_puesto", id_puesto);

            resultado = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return resultado;
        }
        public int EliminarEmpleado(int id)
        {
            int resultado = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = "DELETE FROM empleados WHERE id_empleado = @id";
            MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Parameters.AddWithValue("@id", id);

            resultado = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return resultado;
        }
    }
}
