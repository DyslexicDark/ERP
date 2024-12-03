using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpUsuarios
    {
        private string _usuarioid;
        private string _empleadoid;
        private string _username;
        private string _passwordhash;
        private string _rol;
        private DateTime _fechaRegistro;

        public string UsuarioID
        {
            get { return _usuarioid; }
            set { _usuarioid = value; }
        }

        public string EmpleadoID
        {
            get { return _empleadoid; }
            set { _empleadoid = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string PasswordHash
        {
            get { return _passwordhash; }
            set { _passwordhash = value; }
        }

        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
    }
}
