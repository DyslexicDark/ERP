using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpDetallesCompra
    {
        private string _detalleid;
        private string _compraid;
        private string _productoid;
        private int _cantidad;
        private decimal _precioUnitario;
        private decimal _subtotal;

        public string DetalleID { get => _detalleid; set => _detalleid = value; }
        public string CompraID { get => _compraid; set => _compraid = value; }
        public string ProductoID { get => _productoid; set => _productoid = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public decimal Subtotal { get => _subtotal; set => _subtotal = value; }
    }
}
