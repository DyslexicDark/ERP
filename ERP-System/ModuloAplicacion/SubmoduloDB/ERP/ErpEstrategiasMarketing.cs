using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpEstrategiasMarketing
    {
        private string _estrategiaid;
        private string _nombre;
        private string _descripcion;
        private string _tipo;
        private string _canal;
        private decimal _presupuesto;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private string _estado;
        private DateTime _fechaRegistro;

        public string EstrategiaID { get => _estrategiaid; set => _estrategiaid = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string Canal { get => _canal; set => _canal = value; }
        public decimal Presupuesto { get => _presupuesto; set => _presupuesto = value; }
        public DateTime FechaInicio { get => _fechaInicio; set => _fechaInicio = value; }
        public DateTime FechaFin { get => _fechaFin; set => _fechaFin = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
    }
}
