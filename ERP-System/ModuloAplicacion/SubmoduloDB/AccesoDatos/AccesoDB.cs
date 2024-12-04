using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
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
                    objCommand = new NpgsqlCommand("CREATE DATABASE DB_OFERCOM;", objConnection);
                    objCommand.ExecuteReader();
                    xRespuesta = "si";
                }
                catch (PostgresException ex)
                {
                    //error 1: la base ya existe.
                    //error 2: error en la sentencia sql
                    xRespuesta = "db1";
                }
                catch (Exception ex)
                {
                    xRespuesta = "db2";
                }
                finally
                {
                    objConnection.Dispose();
                }
            }
            catch (PostgresException ex)
            {
                //error 1: el nombre del super-usuario para postgresql no es correcto.
                //error 2: la contraseña del super-usuario para postgresql no es correcta.
                xRespuesta = "db3";
            }
            catch (SocketException ex)
            {
                //error 1: el codigo ip para enlasar con postgresql no es correcto. (opcional localhost)
                //error 2: el número de puerto para enlazar con postgresql no es correcto.
                xRespuesta = "db4";
            }
            catch (Exception ex)
            {
                xRespuesta = "db5";
            }
            objConnection.Close();
            objConnection.Dispose();
            return xRespuesta;
        }
        public static string controlConexionDB()
        {
            string xRespuesta = "no";
            NpgsqlConnection objConnection = new NpgsqlConnection();
            objConnection = ModuloAplicacion.SubmoduloDB.AccesoDatos.Conexiones.ConexionDB();
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                xRespuesta = "si";
            }
            catch (PostgresException ex)
            {
                //error 1: el nombre del super-usuario para postgresql no es correcto.
                //error 2: la contraseña del super-usuario para postgresql no es correcta.
                xRespuesta = "db3";
            }
            catch (SocketException ex)
            {
                //error 1: el codigo ip para enlasar con postgresql no es correcto. (opcional localhost)
                //error 2: el número de puerto para enlazar con postgresql no es correcto.
                xRespuesta = "db4";
            }
            catch (Exception ex)
            {
                xRespuesta = "db5";
            }
            objConnection.Close();
            objConnection.Dispose();
            return xRespuesta;

        }
    }
}
