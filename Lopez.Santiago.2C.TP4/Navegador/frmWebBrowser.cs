﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtHtmlCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial h = new frmHistorial();
            //h.ToString();//Muestra el historial
            h.Show();//muestra el formulario
           
        }

        private void tspbProgreso_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                //mostrar y guardar en historial
                string aux = "";
                string aux2;
                aux = "http://" + txtUrl.Text;
                if (aux.StartsWith("http://"))
                    aux2 = aux;
                else
                    aux2 = "http://" + aux;// string con http:// por defecto

                Uri uri = new Uri(aux2);
                Descargador web = new Descargador(uri);
                web.EventoTiempo += new Hilo.Descargador.EventTiempo(ProgresoDescarga);//llama a ProgresoDescarga y genera la barra de carga
                web.EventoFinal += new Hilo.Descargador.EventRaise(FinDescarga);//Llama a FinDescarga muestra el contenido en rtxtHtmlCode
                Thread hilo = new Thread(web.IniciarDescarga);
                hilo.Start();//inicia el hilo (web.iniciarDescarga)
                //web.IniciarDescarga();
                //FinDescarga(aux2);
                //rtxtHtmlCode.Text = aux2;
                archivos.guardar(aux2);
            }
            catch(Exception auxExc)
            {
                MessageBox.Show("Introducir direccion web!!!");
 
            }
        }
    }
}
