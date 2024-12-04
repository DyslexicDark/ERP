using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.AccesoDatos
{
    internal class AccesoDatosRH
    {
        public static string instaladorTBRH()
        {
            string xRespuesta = "no";
            NpgsqlConnection objConnection = new NpgsqlConnection();
            NpgsqlCommand objCommand = new NpgsqlCommand();
            objConnection = ModuloAplicacion.SubmoduloDB.AccesoDatos.Conexiones.ConexionDB();
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                try
                {
                    objCommand = new NpgsqlCommand("CREATE TABLE RH ( RHID SERIAL PRIMARY KEY, EmpleadoID INT, Fecha DATE NOT NULL, HoraEntrada TIME, HoraSalida TIME,Comentarios VARCHAR(255),FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID));", objConnection);
                    objCommand.ExecuteReader();
                    xRespuesta = "si";
                }
                catch (PostgresException ex)
                {
                    //error 1: la tabla ya existe.
                    //error 2: error en la sentencia sql
                    xRespuesta = "db7";
                }
                catch (Exception ex)
                {
                    xRespuesta = "db8";
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
    }
}
