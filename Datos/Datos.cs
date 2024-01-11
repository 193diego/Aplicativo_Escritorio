using Bohorquez;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Datos
    {
        public bool VerificarUsuario(string nombreUsuario, string clave)
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("VERIFICAR_USUARIO", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", nombreUsuario);
                    cmd.Parameters.AddWithValue("@CLAVE", clave);
                    object existe = cmd.ExecuteScalar();
                    return existe != null && (int)existe == 1;
                }
            }
        }
    }
    public class DatosOrdenProduccion
    {
        public static DataTable ObtenerOrdenesProduccion()
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ORDEN_PRODUCCION", cn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public static void EliminarOrdenProduccion(int numeroOrden)
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("ELIMINAR_ORDEN_PRODUCCION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NUMERO_ORDEN", numeroOrden);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertarOrdenProduccion(string nombreUsuario, int numeroOrden, int cantidad, DateTime fechaInicio, DateTime fechaEntrega, string modelo, string talla, string color, string estadoProduccion, int idMaterial)
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("INSERTAR_ORDEN_PRODUCCION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", nombreUsuario);
                    cmd.Parameters.AddWithValue("@NUMERO_ORDEN", numeroOrden);
                    cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHA_ENTREGA", fechaEntrega);
                    cmd.Parameters.AddWithValue("@MODELO", modelo);
                    cmd.Parameters.AddWithValue("@TALLA", talla);
                    cmd.Parameters.AddWithValue("@COLOR", color);
                    cmd.Parameters.AddWithValue("@ESTADO_PRODUCCION", estadoProduccion);
                    cmd.Parameters.AddWithValue("@ID_MATERIAL", idMaterial);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void EditarOrdenProduccion(string nombreUsuario, int numeroOrden, int cantidad, DateTime fechaInicio, DateTime fechaEntrega, string modelo, string talla, string color, string estadoProduccion, int idMaterial, int idOrdenProduccion)
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("EDITAR_ORDEN_PRODUCCION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", nombreUsuario);
                    cmd.Parameters.AddWithValue("@NUMERO_ORDEN", numeroOrden);
                    cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHA_ENTREGA", fechaEntrega);
                    cmd.Parameters.AddWithValue("@MODELO", modelo);
                    cmd.Parameters.AddWithValue("@TALLA", talla);
                    cmd.Parameters.AddWithValue("@COLOR", color);
                    cmd.Parameters.AddWithValue("@ESTADO_PRODUCCION", estadoProduccion);
                    cmd.Parameters.AddWithValue("@ID_MATERIAL", idMaterial);
                    cmd.Parameters.AddWithValue("@ID_ORDEN_PRODUCCION", idOrdenProduccion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable BuscarOrdenProduccion(string caracter)
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("BUSCAR_ORDEN_PRODUCCION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CARACTER", caracter);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }
    }
    public class DatosMaterial
    {
        public static DataTable ObtenerMateriales()
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID_MATERIAL, NOMBRE_MATERIAL FROM MATERIALES", cn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
    // Tabla Materiales
    public class DatosMateriales
    {
        public static DataTable ObtenerMaterialesI()
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MATERIALES", cn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
    //Tabla Produccion
    public class DatosProduccion
    {
        public static DataTable ObtenerProduccion()
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCCION", cn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
    //
    public class DatosControlCalidad
    {
        public static DataTable ObtenerControlCalidad()
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CONTROL_CALIDAD", cn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}

