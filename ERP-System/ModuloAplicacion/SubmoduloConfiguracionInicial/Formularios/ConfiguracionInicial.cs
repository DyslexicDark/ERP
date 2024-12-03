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
        int xContador = 0;
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
                                crearArchivoConfiguracionInicial(this.textBox2.Text.Trim(), Convert.ToInt32(this.textBox3.Text.Trim()), xTipo, this.textBox1.Text.Trim());
                                if (File.Exists(ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xPath.Trim() + ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreArchivoConfiguracion.Trim()) == true)
                                {
                                    this.listBox1.Items.Insert(0, "El archivo de configuracion inicial se ha creado correctamente.(ci6)...... espere....");
                                    this.button6.Enabled = true;
                                    this.button6.Focus();
                                    this.button5.Enabled = false;
                                    seteoTimer();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (xContador==1)
            {
                this.listBox1.Items.Clear();
                instaladorDB();
                cargaBarra();
            }
            if (xContador==2)
            {
                this.timer1.Stop();
                this.timer1.Dispose();
                MessageBox.Show(ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cuerpoMensajesErrores("ci10"), ModuloAplicacion.SubmoduloConfiguracionInicial.Accesorios.Errores.cabeceraMensajesErrores());
                this.button5.Enabled = true;
            }
            xContador++;
        }
        /*...............Funciones...................................*/
        private void cargaBarra()
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 1;
            this.progressBar1.Step = 1;
            this.progressBar1.PerformStep();
        }
        private void seteoTimer()
        {
            this.timer1.Interval = 3000;
            this.timer1.Enabled = true;
        }
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
        /******************************************************************************/
        private void instaladorDB()
        {
            string xRespuesta = ModuloAplicacion.SubmoduloDB.AccesoDatos.AccesoDB.instaladorBaseDB();
            if(xRespuesta == "si")
            {
                //La base fue creada correctamente
                this.listBox1.Items.Insert(0,"Base DB OFERCOM...................ok");
            }
            else if (xRespuesta == "no")
            {
                //La base no fue creada, no conocemos el error
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db6)");
            }
            else if (xRespuesta == "db1")
            {
                //Controlamos el error del primer try/catch
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db1)");
            }
            else if (xRespuesta == "db2")
            {
                //Controlamos el error del segundo try/catch
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db2)");
            }
            else if (xRespuesta == "db3")
            {
                //Controlamos el error del primer try/catch
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db3)");
            }
            else if (xRespuesta == "db4")
            {
                //Controlamos el error del segundo try/catch
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db4)");
            }
            else if (xRespuesta == "db5")
            {
                //Controlamos el error del segundo try/catch
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db5)");
            }
        }
    }
}
