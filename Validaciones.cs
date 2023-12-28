using System;

namespace Bohorquez
{
    class Validaciones
    {
        public static bool SoloNumeros(string texto)
        {
            foreach (char caracter in texto)
            {
                if (!Char.IsDigit(caracter))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SoloLetras(string texto)
        {
            foreach (char caracter in texto)
            {
                if (!Char.IsLetter(caracter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
