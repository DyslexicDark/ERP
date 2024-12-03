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
                    objCommand = new NpgsqlCommand(@"
                                                        CREATE DATABASE DB_OFERCOM;

                                                        -- Tabla de ubicaciones
                                                        CREATE TABLE Ubicaciones (
                                                            UbicacionID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Tipo VARCHAR(50) NOT NULL CHECK (Tipo IN ('País', 'Estado', 'Ciudad', 'Sucursal')),
                                                            PadreID INT DEFAULT NULL,
                                                            CONSTRAINT FK_PadreUbicacion FOREIGN KEY (PadreID) REFERENCES Ubicaciones(UbicacionID) ON DELETE SET NULL
                                                        );

                                                        -- Tabla de productos
                                                        CREATE TABLE Productos (
                                                            ProductoID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Descripcion VARCHAR(255),
                                                            Precio NUMERIC(10, 2) NOT NULL,
                                                            Stock INT NOT NULL,
                                                            CategoriaID INT,
                                                            ProveedorID INT,
                                                            FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                            FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID),
                                                            FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
                                                        );

                                                        -- Tabla de categorías
                                                        CREATE TABLE Categorias (
                                                            CategoriaID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Descripcion VARCHAR(255)
                                                        );

                                                        -- Tabla de proveedores
                                                        CREATE TABLE Proveedores (
                                                            ProveedorID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Telefono VARCHAR(15),
                                                            Email VARCHAR(100),
                                                            Direccion VARCHAR(255),
                                                            FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                                        );

                                                        -- Tabla de empleados
                                                        CREATE TABLE Empleados (
                                                            EmpleadoID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Apellido VARCHAR(100) NOT NULL,
                                                            Telefono VARCHAR(15),
                                                            Email VARCHAR(100),
                                                            Direccion VARCHAR(255),
                                                            FechaContratacion DATE,
                                                            Puesto VARCHAR(50),
                                                            Salario NUMERIC(10, 2),
                                                            FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                                        );

                                                        -- Tabla de usuarios
                                                        CREATE TABLE Usuarios (
                                                            UsuarioID SERIAL PRIMARY KEY,
                                                            EmpleadoID INT,
                                                            Username VARCHAR(50) UNIQUE NOT NULL,
                                                            PasswordHash VARCHAR(255) NOT NULL,
                                                            Rol VARCHAR(50) NOT NULL CHECK (Rol IN ('Administrador', 'Vendedor', 'Logística', 'Marketing', 'RecursosHumanos')),
                                                            FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                            FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
                                                        );

                                                        -- Tabla de clientes
                                                        CREATE TABLE Clientes (
                                                            ClienteID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Apellido VARCHAR(100),
                                                            Telefono VARCHAR(15),
                                                            Email VARCHAR(100),
                                                            Direccion VARCHAR(255),
                                                            FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                                        );

                                                        -- Tabla de ventas
                                                        CREATE TABLE Ventas (
                                                            VentaID SERIAL PRIMARY KEY,
                                                            ClienteID INT,
                                                            EmpleadoID INT,
                                                            FechaVenta TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                            Total NUMERIC(10, 2),
                                                            FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
                                                            FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
                                                        );

                                                        -- Tabla de detalles de ventas
                                                        CREATE TABLE DetallesVenta (
                                                            DetalleID SERIAL PRIMARY KEY,
                                                            VentaID INT,
                                                            ProductoID INT,
                                                            Cantidad INT NOT NULL,
                                                            PrecioUnitario NUMERIC(10, 2) NOT NULL,
                                                            Subtotal NUMERIC(10, 2) GENERATED ALWAYS AS (Cantidad * PrecioUnitario) STORED,
                                                            FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
                                                            FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
                                                        );

                                                        -- Tabla de compras
                                                        CREATE TABLE Compras (
                                                            CompraID SERIAL PRIMARY KEY,
                                                            ProveedorID INT,
                                                            EmpleadoID INT,
                                                            FechaCompra TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                                            Total NUMERIC(10, 2),
                                                            FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID),
                                                            FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
                                                        );

                                                        -- Tabla de detalles de compras
                                                        CREATE TABLE DetallesCompra (
                                                            DetalleID SERIAL PRIMARY KEY,
                                                            CompraID INT,
                                                            ProductoID INT,
                                                            Cantidad INT NOT NULL,
                                                            PrecioUnitario NUMERIC(10, 2) NOT NULL,
                                                            Subtotal NUMERIC(10, 2) GENERATED ALWAYS AS (Cantidad * PrecioUnitario) STORED,
                                                            FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
                                                            FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
                                                        );

                                                        -- Tabla RH
                                                        CREATE TABLE RH (
                                                            RHID SERIAL PRIMARY KEY,
                                                            EmpleadoID INT,
                                                            Fecha DATE NOT NULL,
                                                            HoraEntrada TIME,
                                                            HoraSalida TIME,
                                                            Comentarios VARCHAR(255),
                                                            FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
                                                        );

                                                        -- Tabla de estrategias de marketing
                                                        CREATE TABLE EstrategiasMarketing (
                                                            EstrategiaID SERIAL PRIMARY KEY,
                                                            Nombre VARCHAR(100) NOT NULL,
                                                            Descripcion VARCHAR(255),
                                                            Tipo VARCHAR(50) NOT NULL CHECK (Tipo IN ('Campaña Publicitaria', 'Evento Promocional', 'Estudio de Mercado')),
                                                            Canal VARCHAR(50) NOT NULL CHECK (Canal IN ('Facebook', 'Instagram', 'WhatsApp', 'Correo', 'Otros')),
                                                            Presupuesto NUMERIC(10, 2),
                                                            FechaInicio DATE,
                                                            FechaFin DATE,
                                                            Estado VARCHAR(50) DEFAULT 'Planeado',
                                                            FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                                        );

                                                        -- Tabla de estadísticas de marketing
                                                        CREATE TABLE EstadisticasMarketing (
                                                            EstadisticaID SERIAL PRIMARY KEY,
                                                            EstrategiaID INT,
                                                            Fecha DATE NOT NULL,
                                                            Clics INT DEFAULT 0,
                                                            Alcance INT DEFAULT 0,
                                                            Conversiones INT DEFAULT 0,
                                                            GastoDiario NUMERIC(10, 2),
                                                            Comentarios VARCHAR(255),
                                                            FOREIGN KEY (EstrategiaID) REFERENCES EstrategiasMarketing(EstrategiaID)
                                                        );
                                                    ", objConnection);
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
