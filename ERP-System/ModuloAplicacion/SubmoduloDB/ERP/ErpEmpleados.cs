using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ModuloAplicacion.SubmoduloDB.ERP
{
    internal class ErpEmpleados
    {
        private string _empleadoid;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _email;
        private string _direccion;
        private DateTime _fechaContratacion;
        private string _puesto;
        private decimal _salario;
        private DateTime _fechaRegistro;

        public string EmpleadoID { get => _empleadoid; set => _empleadoid = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public DateTime FechaContratacion { get => _fechaContratacion; set => _fechaContratacion = value; }
        public string Puesto { get => _puesto; set => _puesto = value; }
        public decimal Salario { get => _salario; set => _salario = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
    }
}
