using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlquilerV
{
    public partial class Principal : Form
    {
        int dato;
        string Placa;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            btncoche.Enabled = false;
            btnmicrobuses.Enabled = false;
            btnfurgonetas.Enabled = false;
            btncamiones.Enabled = false;
            Resultado.Visible = false;
            pma.Visible = false;
            btncalcular.Visible = false;            
            Tvalor.Visible = false;
            btncalcular2.Visible = false;
            Tvalor2.Visible = false;
            matricula1.Visible = false;
        }

        
        public void controlbotones()
        {
            try
            {

                string placa = matricula.Text;
                if (string.IsNullOrWhiteSpace(placa))
                {
                    throw new Exception("La placa está vacía o solo contiene espacios en blanco.");
                }
                matricula1.Text = placa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int dia;
            if (Int32.TryParse(Dias.Text.Trim(), out dia) && Dias.Text.Trim() != string.Empty)
            {
                btncoche.Enabled = true;
                btnmicrobuses.Enabled = true;
                btnfurgonetas.Enabled = true;
                btncamiones.Enabled = true;
                Resultado.Visible = false;
                btncalcular.Visible = false;
                Tvalor.Visible = false;
                pma.Visible = false;
                matricula1.Visible = false;
                errorProvider1.SetError(Dias, "");
            }
            else
            {
                if(!(Dias.Text.All(char.IsDigit)))
                {
                    errorProvider1.SetError(Dias, "Solo se aceptan valores numerico y sin espacios.");
                }
                else
                {
                    errorProvider1.SetError(Dias, "Favor ingresar los Dias a Cotizar.");
                }
                btncoche.Enabled = false;
                btnmicrobuses.Enabled = false;
                btnfurgonetas.Enabled = false;
                btncamiones.Enabled = false;
                Resultado.Visible = false;
                btncalcular.Visible = false;
                Tvalor.Visible = false;
                
            }

            

        }

        private void controlbotones2()
        {
            int valor;
            if (Int32.TryParse(Tvalor.Text.Trim(), out valor) && Tvalor.Text.Trim() != string.Empty)
            {
                btncoche.Enabled = false;
                btnmicrobuses.Enabled = false;
                btnfurgonetas.Enabled = false;
                btncamiones.Enabled = false;
                Resultado.Visible = false;
                btncalcular.Visible = true;
                Tvalor.Visible = true;
                pma.Visible = true;
                matricula1.Visible = false;
                errorProvider2.SetError(Tvalor, "");
            }
            else
            {
                if (!(Tvalor.Text.All(char.IsDigit)))
                {
                    errorProvider2.SetError(Tvalor, "Solo se aceptan valores numerico y sin espacios.");
                }
                else
                {
                    errorProvider2.SetError(Tvalor, "Favor ingresar los PMA a Cotizar.");
                }
                btncoche.Enabled = false;
                btnmicrobuses.Enabled = false;
                btnfurgonetas.Enabled = false;
                btncamiones.Enabled = false;
                Resultado.Visible = false;
                
            }
        }

        private void controlbotones3()
        {
            int valor;
            if (Int32.TryParse(Tvalor2.Text.Trim(), out valor) && Tvalor2.Text.Trim() != string.Empty)
            {
                btncoche.Enabled = false;
                btnmicrobuses.Enabled = false;
                btnfurgonetas.Enabled = false;
                btncamiones.Enabled = false;
                Resultado.Visible = false;
                btncalcular.Visible = false;
                Tvalor.Visible = false;
                pma.Visible = true;
                btncalcular2.Visible = true;
                Tvalor2.Visible = true;
                matricula1.Visible = false;
                errorProvider3.SetError(Tvalor2, "");
            }
            else
            {
                if (!(Tvalor2.Text.All(char.IsDigit)))
                {
                    errorProvider3.SetError(Tvalor2, "Solo se aceptan valores numerico y sin espacios.");
                }
                else
                {
                    errorProvider3.SetError(Tvalor2, "Favor ingresar los PMA a Cotizar.");
                }
                btncoche.Enabled = false;
                btnmicrobuses.Enabled = false;
                btnfurgonetas.Enabled = false;
                btncamiones.Enabled = false;
                Resultado.Visible = false;
                
            }
        }

        private void Dias_TextChanged(object sender, EventArgs e)
        {
            controlbotones();
        }

        public void btncoche_Click(object sender, EventArgs e)
        {
            decimal precioBase = 50;
            decimal precioCocheAdicional = 1.5m;
            decimal dias = int.Parse(Dias.Text);
            Placa = (matricula.Text);

            decimal precioFinal = (int)((precioBase + precioCocheAdicional) * dias);
            Resultado.Text = "El valor a Pagar por el alquiler del coche es: "+precioFinal.ToString("N2") +" COP.";
            matricula1.Text = "Matricula: " + Placa;
            matricula1.Visible = true;
            Resultado.Visible = true;

        }

        private void btnmicrobuses_Click(object sender, EventArgs e)
        {
            double precioBase = 50;
            
            int dias = int.Parse(Dias.Text);
            Placa = (matricula.Text);

            double precioFinal = (int)((precioBase * dias) + 2);
            Resultado.Text = "El valor a Pagar por el alquiler de Microbus es: " + precioFinal.ToString("N2") + " COP.";
            Resultado.Visible = true;
            matricula1.Text = "Matricula: " + Placa;
            matricula1.Visible = true;
        }

        private void btnfurgonetas_Click(object sender, EventArgs e)
        {
            dato = int.Parse(Dias.Text);

            label2.Visible = false;
            Dias.Visible = false;
            btncalcular.Visible = true;
            Tvalor.Visible = true;
            btncalcular.Visible = true;
            btncoche.Enabled = false;
            btnmicrobuses.Enabled = false;
            btnfurgonetas.Enabled = false;
            btncamiones.Enabled = false;
            pma.Visible = true;

           

        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            double precioBase = 50;
            int pma = 20;
            int tvalor = int.Parse(Tvalor.Text);
            Placa = (matricula.Text);
            double precioFinal = (int)((precioBase * dato)+(tvalor * pma));
            Resultado.Text = "El valor a Pagar por el alquiler de Furgoneta de Carga es: " + precioFinal.ToString("N2") + " COP.";
            Resultado.Visible = true;
            matricula1.Text = "Matricula: " + Placa;
            matricula1.Visible = true;



        }

        private void Tvalor_TextChanged(object sender, EventArgs e)
        {
            controlbotones2();
        }

        private void Tvalor2_TextChanged(object sender, EventArgs e)
        {
            controlbotones3();
        }

        private void btncamiones_Click(object sender, EventArgs e)
        {
            dato = int.Parse(Dias.Text);

            label2.Visible = false;
            Dias.Visible = false;
            btncalcular.Visible = false;
            Tvalor.Visible = false;
            btncalcular.Visible = true;
            btncoche.Enabled = false;
            btnmicrobuses.Enabled = false;
            btnfurgonetas.Enabled = false;
            btncamiones.Enabled = false;
            btncalcular2.Visible = true;
            Tvalor2.Visible = true;
            pma.Visible = true;
        }

        private void btncalcular2_Click(object sender, EventArgs e)
        {
            double precioBase = 50;
            int pma = 20;
            int tvalor = int.Parse(Tvalor2.Text);
            Placa = (matricula.Text);

            double precioFinal = (int)((precioBase * dato) + (tvalor * pma)+40);
            Resultado.Text = "El valor a Pagar por el alquiler de Caminoneta de Carga es: " + precioFinal.ToString("N2") + " COP.";
            Resultado.Visible = true;
            matricula1.Text = "Matricula: " + Placa;
            matricula1.Visible = true;
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {             
            Application.Restart();
        }

        private void matricula_TextChanged(object sender, EventArgs e)
        {
            controlbotones();
        }
    }
}
