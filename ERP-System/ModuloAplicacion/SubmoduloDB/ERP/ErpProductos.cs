using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpProductos
    {
        private string _productoid;
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private int _stock;
        private string _categoriaid;
        private string _proveedorid;
        private DateTime _fechaRegistro;

        public string ProductoID
        {
            get { return _productoid; }
            set { _productoid = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public string CategoriaID
        {
            get { return _categoriaid; }
            set { _categoriaid = value; }
        }

        public string ProveedorID
        {
            get { return _proveedorid; }
            set { _proveedorid = value; }
        }

        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
    }
}
