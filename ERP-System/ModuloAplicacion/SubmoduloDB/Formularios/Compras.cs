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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }
        private void Compras_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "Compras.cs" + " | " + "Usuario: " + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreUsuarioSesion.Trim() + " | " + "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }
    }
}
