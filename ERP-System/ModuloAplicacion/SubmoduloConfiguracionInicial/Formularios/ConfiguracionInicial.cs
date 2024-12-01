using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModuloAplicacion.SubmoduloConfiguracionInicial.Formularios
{
    public partial class ConfiguracionInicial : Form
    {
        public ConfiguracionInicial()
        {
            InitializeComponent();
        }
        /*...............Variables y constantes......................*/
        /*...............Eventos.....................................*/
        private void ConfiguracionInicial_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "ConfiguracionInicial.cs" + "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string xTipo = "";
            if(this.radioButton1.Checked==true||this.radioButton2.Checked==true)
            {
                if(this.textBox1.Text.Trim()!="")
                {
                    if (this.textBox2.Text.Trim() != "")
                    {
                        if (this.textBox3.Text.Trim() != "")
                        {
                            if(this.radioButton1.Checked == true)
                            {
                                xTipo = "ts";
                            }
                            else
                            {
                                xTipo = "t";
                            }
                            try
                            {
                                crearArchivoConfiguracionInicial(this.textBox3.Text.Trim(), Convert.ToInt32(this.textBox2.Text.Trim()), xTipo, this.textBox1.Text.Trim());
                                if (File.Exists(ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xPath.Trim() + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreArchivoConfiguracion.Trim()) == true)
                                {
                                    MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci6"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                                    this.button6.Enabled = true;
                                    this.button6.Focus();
                                    DB();
                                }
                                else
                                {
                                    MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci5"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                                }
                            }
                            catch (FormatException ex)
                            {
                                MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci7"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                                this.textBox2.Focus();
                            }
                            catch (DirectoryNotFoundException ex)
                            {
                                MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci8"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci9"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                            }
                        }
                        else
                        {
                            MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci4"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                            this.textBox3.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci3"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                        this.textBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci2"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                    this.textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci1"),ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ModuloAplicacion.SubmoduloControlConexion.Formulario.ControlConexion formControlConexion = new ModuloAplicacion.SubmoduloControlConexion.Formulario.ControlConexion();
            formControlConexion.Show();
        }
        private void ConfiguracionInicial_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /*...............Funciones...................................*/
        public void crearArchivoConfiguracionInicial(string xCodigoIp, int xNumeroPuerto, string xTipoTerminal, string xNombreTerminal)
        {
            StreamWriter sw = new StreamWriter(ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xPath.Trim() + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreArchivoConfiguracion.Trim());
            // es el codigo ip del equipo que contiene al servidor de datos.
            sw.WriteLine("servidorip:" + xCodigoIp + ";");
            ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xIpServidor = xCodigoIp;
            // nro. de puerto de escucha dell servidor de datos.
            sw.WriteLine("puerto:"+ xNumeroPuerto +";");
            ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xPuertoServidor = xNumeroPuerto;
            // tipo de terminal a instalar
            sw.WriteLine("terminal:" + xTipoTerminal + ";");
            ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xTipoTerminal = xTipoTerminal;
            // nombre de la terminal
            sw.WriteLine("nombre:" + xNombreTerminal + ";");
            ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreTerminal = xNombreTerminal;
            sw.Close();
        }
        private void DB()
        {

        }
    }
}
