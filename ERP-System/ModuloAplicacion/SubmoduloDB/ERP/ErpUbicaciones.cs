using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpUbicaciones
    {
        private string _ubicacionid;
        private string _nombre;
        private string _tipo;
        private string _padreid;

        public string UbicacionID
        {
            get { return _ubicacionid; }
            set { _ubicacionid = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string PadreID
        {
            get { return _padreid; }
            set { _padreid = value; }
        }
    }
}
