using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloAplicacion.SubmoduloDB.Formularios
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        /*............Variables y constantes.............*/
        /*............Eventos............................*/
        private void Productos_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "Productos.cs" + " | " + "Usuario: " + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreUsuarioSesion.Trim() + " | " + "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }
        /*............Funciones..........................*/
    }
}
