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

}
