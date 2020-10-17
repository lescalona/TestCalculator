using System;
using System.IO;
using System.Windows.Forms;

namespace Calculator.WindowsUi
{
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        }

        double a;
        double b;
        string c;

        private void btnUno_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "1";
            }
            else
            {
                txtValorPantalla.Text += "1";
            }
        }

        private void btnDos_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "2";
            }
            else
            {
                txtValorPantalla.Text += "2";
            }
        }

        private void btnTres_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "3";
            }
            else
            {
                txtValorPantalla.Text += "3";
            }
        }

        private void btnCuatro_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "4";
            }
            else
            {
                txtValorPantalla.Text += "4";
            }
        }

        private void btnCinco_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "5";
            }
            else
            {
                txtValorPantalla.Text += "5";
            }
        }

        private void btnSeis_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "6";
            }
            else
            {
                txtValorPantalla.Text += "6";
            }
        }

        private void btnSiete_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "7";
            }
            else
            {
                txtValorPantalla.Text += "7";
            }
        }

        private void btnOcho_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "8";
            }
            else
            {
                txtValorPantalla.Text += "8";
            }
        }

        private void btnNueve_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "9";
            }
            else
            {
                txtValorPantalla.Text += "9";
            }
        }

        private void btnCero_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text == "")
            {
                txtValorPantalla.Text = "0";
            }
            else
            {
                txtValorPantalla.Text += "0";
            }
        }

        private void btnDecinal_Click(object sender, System.EventArgs e)
        {
            if (txtValorPantalla.Text.Contains(".") == false)
            {
                txtValorPantalla.Text += ".";
            }
        }

        private void btnSuma_Click(object sender, System.EventArgs e)
        {
            a = Convert.ToDouble(txtValorPantalla.Text);
            c = "+";
            txtValorPantalla.Clear();
            txtValorPantalla.Focus();
        }


        private void btnResta_Click(object sender, System.EventArgs e)
        {
            a = Convert.ToDouble(txtValorPantalla.Text);
            c = "-";
            txtValorPantalla.Clear();
            txtValorPantalla.Focus();
        }

        private void btnMultiplica_Click(object sender, System.EventArgs e)
        {
            a = Convert.ToDouble(txtValorPantalla.Text);
            c = "*";
            txtValorPantalla.Clear();
            txtValorPantalla.Focus();
        }

        private void btnDivide_Click(object sender, System.EventArgs e)
        {
            a = Convert.ToDouble(txtValorPantalla.Text);
            c = "/";
            txtValorPantalla.Clear();
            txtValorPantalla.Focus();
        }

        private void btnHistorial_Click(object sender, System.EventArgs e)
        {
            string filePath = "Ruta\\historial.txt";
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }

            StreamWriter Archivo = new StreamWriter(filePath);
            Archivo.WriteLine("Operaciones: " + a + c + b + "=" + txtValorPantalla.Text);
            Archivo.Flush();
            Archivo.Close();

            System.Diagnostics.Process.Start(filePath);
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            a = Convert.ToDouble(0);
            b = Convert.ToDouble(0);
            txtValorPantalla.Text = "";
            c = "";
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            b = Convert.ToDouble(txtValorPantalla.Text);
            switch (c)
            {
                case "+":
                    txtValorPantalla.Text = Convert.ToString(b + a);
                    break;

                case "-":
                    txtValorPantalla.Text = Convert.ToString(b - a);
                    break;

                case "*":
                    txtValorPantalla.Text = Convert.ToString(b * a);
                    break;

                case "/":
                    txtValorPantalla.Text = Convert.ToString(b / a);
                    break;
            }
        }
    }
}
