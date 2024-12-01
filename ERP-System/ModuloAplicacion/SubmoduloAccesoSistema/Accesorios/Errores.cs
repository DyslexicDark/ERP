using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAplicacion.SubmoduloAccesoSistema.Accesorios
{
    internal class Errores
    {
        public static string cabeceraMensajesErrores()
        {
            string xRespuesta = "Sistema de mensajes";
            return xRespuesta;
        }
        public static string cuerpoMensajesErrores(string xCodigoError)
        {
            string xRespuesta = "";
            switch (xCodigoError)
            {
                case "as1":
                    xRespuesta = "Debes ingresar nombre de usuario.(as1)";
                    break;
                case "as2":
                    xRespuesta = "Debes ingresar tu contraseña.(as2)";
                    break;
                case "as3":
                    xRespuesta = "El nombre del usuario ingresado no existe.(as3)";
                    break;
                case "as4":
                    xRespuesta = "La contraseña ingresada no pertenece al usuario.(as4)";
                    break;
            }
            return xRespuesta;
        }
    }
}
