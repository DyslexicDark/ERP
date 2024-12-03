using System;
using System.CodeDom;
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
        int xContador = 0;
        string xControl = "si";
        /*...............Eventos.............................*/
        private void ControlConexion_Load(object sender, EventArgs e)
        {
            this.Text = ModuloAplicacion.SubmoduloPresentacion.Formularios.Presentacion.xNombreSistema.Trim();
            this.toolStripStatusLabel1.Text = "ControlConexion.cs" + "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            seteoTimer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (xContador==1)
            {
                ControlConexionDB();
                cargaBarra();
            }
            if (xContador == 2)
            {
                this.timer1.Stop();
                this.timer1.Dispose();
                if (xControl == "no")
                {
                    //mensaje de error de conexion
                    MessageBox.Show(ModuloAplicacion.SubmoduloControlConexion.Accesorios.Errores.cuerpoMensajesErrores("cc1"),ModuloAplicacion.SubmoduloControlConexion.Accesorios.Errores.cabeceraMensajesErrores());
                    this.groupBox2.Enabled = true;
                }
                else
                {
                    this.Hide();
                    ModuloAplicacion.SubmoduloAccesoSistema.Formularios.AccesoSistema formAccesoSistema = new ModuloAplicacion.SubmoduloAccesoSistema.Formularios.AccesoSistema();
                    formAccesoSistema.Show();
                }
            }
            xContador++;
        }
        /*...............Funciones...........................*/
        private void seteoTimer()
        {
            this.timer1.Interval = 3000;
            this.timer1.Enabled = true;
        }
        private void cargaBarra()
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 1;
            this.progressBar1.Step = 1;
            this.progressBar1.PerformStep();
        }
        /***************************************************/
        private void ControlConexionDB()
        {
            string xRespuesta = ModuloAplicacion.SubmoduloDB.AccesoDatos.AccesoDB.controlConexionDB();
            if (xRespuesta == "si")
            {
                //la conoexion fue correcta
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................ok");
            }
            else if (xRespuesta == "no")
            {
                //error desconocido
                xControl = "no";
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db6)");
            }
            else if (xRespuesta == "db3")
            {
                xControl = "no";
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db3)");
            }
            else if (xRespuesta == "db4")
            {
                xControl = "no";
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db4)");
            }
            else if (xRespuesta == "db5")
            {
                xControl = "no";
                this.listBox1.Items.Insert(0, "Base DB OFERCOM...................error(db5)");
            }
        }
    }
}
