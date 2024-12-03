using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpVentas
    {
        private string _ventaid;
        private string _clienteid;
        private string _empleadoid;
        private decimal _total;
        private DateTime _fechaVenta;

        public string VentaID
        {
            get { return _ventaid; }
            set { _ventaid = value; }
        }

        public string ClienteID
        {
            get { return _clienteid; }
            set { _clienteid = value; }
        }

        public string EmpleadoID
        {
            get { return _empleadoid; }
            set { _empleadoid = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public DateTime FechaVenta
        {
            get { return _fechaVenta; }
            set { _fechaVenta = value; }
        }
    }
}
