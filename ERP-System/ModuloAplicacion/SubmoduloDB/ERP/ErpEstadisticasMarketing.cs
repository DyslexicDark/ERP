using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpEstadisticasMarketing
    {
        private string _estadisticaid;
        private string _estrategiaid;
        private DateTime _fecha;
        private int _clics;
        private int _alcance;
        private int _conversiones;
        private decimal _gastoDiario;
        private string _comentarios;

        public string EstadisticaID { get => _estadisticaid; set => _estadisticaid = value; }
        public string EstrategiaID { get => _estrategiaid; set => _estrategiaid = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int Clics { get => _clics; set => _clics = value; }
        public int Alcance { get => _alcance; set => _alcance = value; }
        public int Conversiones { get => _conversiones; set => _conversiones = value; }
        public decimal GastoDiario { get => _gastoDiario; set => _gastoDiario = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }
    }
}
