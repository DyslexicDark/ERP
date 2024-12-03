using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpCompras
    {
        private string _compraid;
        private string _proveedorid;
        private string _empleadoid;
        private DateTime _fechaCompra;
        private decimal _total;

        public string CompraID { get => _compraid; set => _compraid = value; }
        public string ProveedorID { get => _proveedorid; set => _proveedorid = value; }
        public string EmpleadoID { get => _empleadoid; set => _empleadoid = value; }
        public DateTime FechaCompra { get => _fechaCompra; set => _fechaCompra = value; }
        public decimal Total { get => _total; set => _total = value; }
    }
}
