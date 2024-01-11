using Datos;
using System;
using System.Data;

namespace Logica
{
    public class Logica
    {
        private Datos.Datos datosUsuario = new Datos.Datos();

        public bool AutenticarUsuario(string nombreUsuario, string clave)
        {
            return datosUsuario.VerificarUsuario(nombreUsuario, clave);
        }
    }
    // ORDEN PRODUCCION
    public class LogicaOrdenProduccion
    {
        public static DataTable ObtenerOrdenesProduccion()
        {
            return DatosOrdenProduccion.ObtenerOrdenesProduccion();
        }
        public static void InsertarOrdenProduccion(string nombreUsuario, int numeroOrden, int cantidad, DateTime fechaInicio, DateTime fechaEntrega, string modelo, string talla, string color, string estadoProduccion, int idMaterial)
        {
            DatosOrdenProduccion.InsertarOrdenProduccion(nombreUsuario, numeroOrden, cantidad, fechaInicio, fechaEntrega, modelo, talla, color, estadoProduccion, idMaterial);
        }
        public static void EditarOrdenProduccion(string nombreUsuario, int numeroOrden, int cantidad, DateTime fechaInicio, DateTime fechaEntrega, string modelo, string talla, string color, string estadoProduccion, int idMaterial, int idOrdenProduccion)
        {
            DatosOrdenProduccion.EditarOrdenProduccion(nombreUsuario, numeroOrden, cantidad, fechaInicio, fechaEntrega, modelo, talla, color, estadoProduccion, idMaterial, idOrdenProduccion);
        }
        public static void EliminarOrdenProduccion(int numeroOrden)
        {
            DatosOrdenProduccion.EliminarOrdenProduccion(numeroOrden);
        }
        public static DataTable BuscarOrdenProduccion(string caracter)
        {
            return DatosOrdenProduccion.BuscarOrdenProduccion(caracter);
        }
    }
    public class LogicaMaterial
    {
        public static DataTable ObtenerMateriales()
        {
            return DatosMaterial.ObtenerMateriales();
        }
    }
    // MATERIALES 
    public class LogicaMateriales
    {
        public static DataTable ObtenerMaterialesI()
        {
            return DatosMateriales.ObtenerMaterialesI();
        }
    }
    // PRODUCCION
    public class LogicaProduccion
    {
        public static DataTable ObtenerProduccion()
        {
            return DatosProduccion.ObtenerProduccion();
        }
    }
    // CONTROL DE CALIDAD
    public class LogicaControlCalidad
    {
        public static DataTable ObtenerControlCalidad()
        {
            return DatosControlCalidad.ObtenerControlCalidad();
        }
    }

}
