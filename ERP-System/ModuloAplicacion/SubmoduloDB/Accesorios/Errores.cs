using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAplicacion.SubmoduloDB.Accesorios
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
                case "db1":
                    xRespuesta = "La base de datos ya existe. Tambien puede haber un error en la sentencia sql.(db1)";
                    break;
                case "db2":
                    xRespuesta = "Se produjo un error desconocido.(db2)";
                    break;
                case "db3":
                    xRespuesta = "Existe un error al enlazar con el servidor de datos.(db3)";
                    break;
                case "db4":
                    xRespuesta = "Existe un error al enlazar con el servidor de datos.(db4)";
                    break;
                case "db5":
                    xRespuesta = "Se produjo un error desconocido.(db5)";
                    break;
                case "db6":
                    xRespuesta = "Se produjo un error desconocido.(db6)";
                    break;
                case "db7":
                    xRespuesta = "La tabla de datos ya existe. Tambien puede haber un error en la sentencia sql.(db7)";
                    break;
                case "db8":
                    xRespuesta = "Se produjo un error desconocido.(db8)";
                    break;
            }
            return xRespuesta;
        }
    }
}
