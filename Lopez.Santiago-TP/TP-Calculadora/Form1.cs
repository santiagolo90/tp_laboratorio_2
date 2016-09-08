using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Calculadora
{
    public partial class Form1 : Form
    {
        string op="";
        double rt;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Calculadora c1 = new Calculadora();

            this.txtNumero1.Text = c1.Limpiar();
            this.txtNumero2.Text = c1.Limpiar();
            this.cmbOperacion.Text = "";
            lblResultado.Text = c1.Limpiar();
           
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Calculadora c1 = new Calculadora();
            Numero n1 = new Numero(this.txtNumero1.Text);
            Numero n2 = new Numero(this.txtNumero2.Text);
            this.op = cmbOperacion.Text;
            Calculadora.validarOperador(op);
            //Calculadora.operar(n1,n2,op);
            rt = Calculadora.operar(n1, n2, op);
            
            lblResultado.Text = rt.ToString();

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           //this.op = cmbOperacion.
        }
    }
}
