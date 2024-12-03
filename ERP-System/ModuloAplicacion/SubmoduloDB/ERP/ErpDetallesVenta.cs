using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpDetallesVenta
    {
        private string _detalleid;
        private string _ventaid;
        private string _productoid;
        private int _cantidad;
        private decimal _precioUnitario;
        private decimal _subtotal;

        public string DetalleID
        {
            get { return _detalleid; }
            set { _detalleid = value; }
        }

        public string VentaID
        {
            get { return _ventaid; }
            set { _ventaid = value; }
        }

        public string ProductoID
        {
            get { return _productoid; }
            set { _productoid = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public decimal PrecioUnitario
        {
            get { return _precioUnitario; }
            set { _precioUnitario = value; }
        }

        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }
    }
}
