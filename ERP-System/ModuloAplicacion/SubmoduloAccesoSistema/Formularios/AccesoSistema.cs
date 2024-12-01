using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloAplicacion.SubmoduloAccesoSistema.Formularios
{
    public partial class AccesoSistema : Form
    {
        public AccesoSistema()
        {
            InitializeComponent();
        }
        /*..................Variables y constantes..................*/
        /*..................Eventos.................................*/
        private void AccesoSistema_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "AccesoSistema.cs" + "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            this.textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if(this.textBox1.Text.Trim()!="")
                {
                    this.textBox2.Focus();
                }
                else
                {
                    MessageBox.Show(ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cuerpoMensajesErrores("as1"), ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cabeceraMensajesErrores());
                    this.textBox1.Focus();
                }
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (this.textBox2.Text.Trim() != "")
                {
                    this.button5.Focus();
                }
                else
                {
                    MessageBox.Show(ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cuerpoMensajesErrores("as2"), ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cabeceraMensajesErrores());
                    this.textBox2.Focus();
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() != "")
            {
                if (this.textBox2.Text.Trim() != "")
                {
                    if (this.textBox1.Text.Trim() == ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSuperUsuario.Trim())
                    {
                        if (this.textBox2.Text.Trim() == ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xClaveSuperUsuario.Trim())
                        {
                            //evaluar la contraseña
                            this.Hide();
                            ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreUsuarioSesion = this.textBox1.Text.Trim();
                            ModuloAplicacion.SubmoduloMenuPrincipal.Formularios.MenuPrincipal formMenuPrincipal = new ModuloAplicacion.SubmoduloMenuPrincipal.Formularios.MenuPrincipal();
                            formMenuPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show(ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cuerpoMensajesErrores("as4"), ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cabeceraMensajesErrores());
                            this.textBox2.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show(ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cuerpoMensajesErrores("as3"), ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cabeceraMensajesErrores());
                        this.textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cuerpoMensajesErrores("as2"), ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cabeceraMensajesErrores());
                    this.textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show(ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cuerpoMensajesErrores("as1"), ModuloAplicacion.SubmoduloAccesoSistema.Accesorios.Errores.cabeceraMensajesErrores());
                this.textBox1.Focus();
            }
        }

        private void AccesoSistema_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /*..................Funciones...............................*/

    }
}
