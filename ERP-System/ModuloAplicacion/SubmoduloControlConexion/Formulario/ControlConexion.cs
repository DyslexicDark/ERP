using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloAplicacion.SubmoduloControlConexion.Formulario
{
    public partial class ControlConexion : Form
    {
        public ControlConexion()
        {
            InitializeComponent();
        }
        /*...............Variables y constantes..............*/
        /*...............Eventos.............................*/
        private void ControlConexion_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "ControlConexion.cs" + "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModuloAplicacion.SubmoduloAccesoSistema.Formularios.AccesoSistema formAccesoSistema = new SubmoduloAccesoSistema.Formularios.AccesoSistema();
            formAccesoSistema.Show();
        }
        /*...............Funciones...........................*/

    }
}
