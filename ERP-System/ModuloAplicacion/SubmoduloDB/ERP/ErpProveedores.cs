using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpProveedores
    {
        private string _proveedorid;
        private string _nombre;
        private string _telefono;
        private string _email;
        private string _direccion;
        private DateTime _fechaRegistro;

        public string ProveedorID
        {
            get { return _proveedorid; }
            set { _proveedorid = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
    }
}
