using Bohorquez;
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
}
