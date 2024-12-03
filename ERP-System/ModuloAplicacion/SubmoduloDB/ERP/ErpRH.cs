using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpRH
    {
        private string _rhid;
        private string _empleadoid;
        private DateTime _fecha;
        private TimeSpan _horaEntrada;
        private TimeSpan _horaSalida;
        private string _comentarios;

        public string RHID
        {
            get { return _rhid; }
            set { _rhid = value; }
        }

        public string EmpleadoID
        {
            get { return _empleadoid; }
            set { _empleadoid = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public TimeSpan HoraEntrada
        {
            get { return _horaEntrada; }
            set { _horaEntrada = value; }
        }

        public TimeSpan HoraSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }

        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }
    }
}
