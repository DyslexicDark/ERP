using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.AccesoDatos
{
    internal class Conexiones
    {
        public static NpgsqlConnection ConexionServidorDatos()
        {
            string xConexion =  "server=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xIpServidor.Trim() + 
                                ";port=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xPuertoServidor +
                                ";user id=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreUsuarioServidor.Trim() +
                                ";password=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xClaveUsuarioServidor.Trim();
            try
            {
                NpgsqlConnection objConnection = new NpgsqlConnection(xConexion);
                return objConnection;
            }
            catch (Exception ex)
            {
                NpgsqlConnection objConnection = new NpgsqlConnection();
                return objConnection;
            }
        }
        public static NpgsqlConnection ConexionDB()
        {
            string xConexion = "server=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xIpServidor.Trim() +
                                ";port=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xPuertoServidor +
                                ";database=DB_OFERCOM;user id=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreUsuarioServidor.Trim() +
                                ";password=" + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xClaveUsuarioServidor.Trim();
            try
            {
                NpgsqlConnection objConnection = new NpgsqlConnection(xConexion);
                return objConnection;
            }
            catch (Exception ex)
            {
                NpgsqlConnection objConnection = new NpgsqlConnection();
                return objConnection;
            }
        }
    }
}
