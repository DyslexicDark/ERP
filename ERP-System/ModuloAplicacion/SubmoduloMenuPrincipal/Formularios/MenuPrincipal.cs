using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloAplicacion.SubmoduloMenuPrincipal.Formularios
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        /*..................Variables y constantes..................*/
        /*..................Eventos.................................*/
        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "MenuPrincipal.cs" + " | " + "Usuario: " + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreUsuarioSesion.Trim() + " - Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuloAplicacion.SubmoduloDB.Formularios.RH formRH = new ModuloAplicacion.SubmoduloDB.Formularios.RH();
            formRH.ShowDialog();
        }
        /*..................Funciones...............................*/
    }
}
