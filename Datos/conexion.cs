using System.Data.SqlClient;

namespace Bohorquez
{
    class conexion
    {
        public static SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection("server=LAPTOP-P821MMUI;database=CAMISAS_POLOS;integrated security=true;");
            cn.Open();
            return cn;
        }
    }
}
