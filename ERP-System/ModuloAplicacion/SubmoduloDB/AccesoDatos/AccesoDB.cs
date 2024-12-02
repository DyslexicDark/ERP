using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.AccesoDatos
{
    internal class AccesoDB
    {
        public static string instaladorBaseDB()
        {
            string xRespuesta = "no";
            NpgsqlConnection objConnection = new NpgsqlConnection();
            NpgsqlCommand objCommand = new NpgsqlCommand();
            objConnection = ModuloAplicacion.SubmoduloDB.AccesoDatos.Conexiones.ConexionServidorDatos();
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                try
                {
                    objCommand = new NpgsqlCommand("CREATE DATABASE OFERCOM", objConnection);
                    objCommand.ExecuteReader();
                    xRespuesta = "si";
                    objCommand.Dispose();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    objConnection.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            objConnection.Close();
            objConnection.Dispose();
            return xRespuesta;
        }
    }
}
