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

namespace ModuloAplicacion.SubmoduloPresentacion.Formularios
{
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        /*............... Variables y constantes..............*/
        // nombre del archivo de configuracion inicial.
        public static string xNombreArchivoConfiguracion = "config.txt";
        //direccion fisica del archivo inicial
        public static string xPath = "D:\\Documents\\Documentos\\Materias\\Tópico Selecto de Sistemas de Información\\ERP\\ERP-System\\";
        //codigo ip del servidor de datos.
        public static string xIpServidor = "";
        //nro de puerto de escucha del sercidor de datos
        public static int xPuertoServidor = 0;
        //nombre del usuario del servidor(o super-usuario)
        public static string xNombreUsuarioServidor = "postgres";
        //contraseña del usuario del servidor
        public static string xClaveUsuarioServidor = "7368";
        //tipo de la terminal a instalada
        public static string xTipoTerminal = "";
        //nombre de la terminal a instalar
        public static string xNombreTerminal = "";
        //nombre del usuario que inicia sesion
        public static string xNombreUsuarioSesion = "";
        //nombre asignado al sistema
        public static string xNombreSistema = "OFERCOM";
        //nombre del super-usuario
        public static string xNombreSuperUsuario = "admin";
        //contraseña del super-usuario
        public static string xClaveSuperUsuario = "123";

        /*............... Eventos.............................*/

        private void Presentacion_Load(object sender, EventArgs e)
        {
            seteoTimer();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buscarArchivoConfiguracionInicial();
        }

        /*............... Funciones............................*/
        private void seteoTimer()
        {
            this.timer1.Interval = 3000;
            this.timer1.Enabled = true;
        }
        private void buscarArchivoConfiguracionInicial()
        {
            this.timer1.Stop();
            this.timer1.Dispose();
            if(File.Exists(xPath + xNombreArchivoConfiguracion))
            {
                //El archivo existe
                lecturaExtraccion();
                this.Hide();
                ModuloAplicacion.SubmoduloControlConexion.Formulario.ControlConexion formControlConexion = new ModuloAplicacion.SubmoduloControlConexion.Formulario.ControlConexion();
                formControlConexion.Show();
            }
            else
            {
                //El archivo no existe
                this.Hide();
                ModuloAplicacion.SubmoduloConfiguracionInicial.Formularios.ConfiguracionInicial formConfiguracionInincial = new ModuloAplicacion.SubmoduloConfiguracionInicial.Formularios.ConfiguracionInicial();
                formConfiguracionInincial.Show();
            }
        }
        private void lecturaExtraccion()
        {
            StreamReader lectura = new StreamReader(xPath + xNombreArchivoConfiguracion, true);
            if(lectura.Peek() > -1)
            {
                string xCadena = lectura.ReadToEnd();
                string xPalabra = "";
                int xContador = 0;
                string xDato = "no";
                foreach(char xLetra in xCadena)
                {
                    if (xDato == "si")
                    {
                        if(xLetra != Convert.ToChar(";"))
                        {
                            //vamos formando la palabra
                            xPalabra = xPalabra + xLetra;
                        }
                    }
                    if(xLetra == Convert.ToChar(":"))
                    {
                        xDato = "si";
                    }
                    if(xLetra == Convert.ToChar(";"))
                    {
                        xDato = "no";
                        xContador++;
                        //asignamos el contenido de la palabra formada a cada variable
                        if(xContador==1)
                        {
                            xIpServidor = xPalabra;
                        }
                        else if (xContador == 2)
                        {
                            xPuertoServidor = Convert.ToInt32(xPalabra);
                        }
                        else if (xContador == 3)
                        {
                            xTipoTerminal = xPalabra;
                        }
                        else if (xContador == 4)
                        {
                            xNombreTerminal = xPalabra;
                        }
                        xPalabra = "";
                    }
                }
            }
        }

    }
}
