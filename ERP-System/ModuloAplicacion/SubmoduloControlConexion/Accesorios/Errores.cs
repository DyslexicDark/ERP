using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAplicacion.SubmoduloControlConexion.Accesorios
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
                case "cc1":
                    xRespuesta = "Se produjo un error al intentar conectarse con una o varias bases de datos.(cc1)";
                    break;
                case "cc2":
                    xRespuesta = ".(cc1)";
                    break;
                case "cc3":
                    xRespuesta = ".(cc1)";
                    break;
            }
            return xRespuesta;
        }
    }
}
