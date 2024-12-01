using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios
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
                case "ci1":
                    xRespuesta = "Debes seleccionar el tipo de terminal a instalar.(ci1)";
                    break;
                case "ci2":
                    xRespuesta = "Debes agregar un nombre para esta terminal.(ci2)";
                    break;
                case "ci3":
                    xRespuesta = "Debes ingresar el codigo ip del equipo donde se encuentra el servidor de datos.(ci3)";
                    break;
                case "ci4":
                    xRespuesta = "Debes ingresar el numero de puerto de escucha del servidor de datos.(ci4)";
                    break;
                case "ci5":
                    xRespuesta = "El archivo de configuracion inicial 'NO' se a creado.(ci5)";
                    break;
                case "ci6":
                    xRespuesta = "El archivo de configuracion inicial se ha creado correctamente.(ci6)";
                    break;
                case "ci7":
                    xRespuesta = "Debes ingresar el numero de puerto correcto.(ci7)";
                    break;
                case "ci8":
                    xRespuesta = "El directorio establecido para el archivo de configuración no existe.(ci8)";
                    break;
                case "ci9":
                    xRespuesta = "Existe un error desconocido generado al momento de crear el archivo de configuración.(ci9)";
                    break;
            }
            return xRespuesta;
        }
    }
}
