using System;
using System.IO;
using System.Windows.Forms;

namespace Calculator.WindowsUi
{
    public partial class FormCalculator : Form
    {
       private double _operando1 = 0;
        private double _operando2 = 0;
        private double _resultado = 0;
        private string _operacion = "";
        private bool _nuevoNumero = true;
        private readonly List<string> _historial = new List<string>();

        private readonly string _conexionString = "Data Source=nombre_servidor;Initial Catalog=nombre_base_de_datos;User ID=nombre_usuario;Password=contraseña_usuario;";

        public FormCalculator()
        {
            InitializeComponent();
        }

        private void FormCalculator_Load(object sender, EventArgs e)
        {
            // Main window configuration
            this.Text = "Calculadora";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Button configuration
            int btnWidth = 50;
            int btnHeight = 50;
            int btnMargin = 5;

            Button btn0 = new Button();
            btn0.Name = "btn0";
            btn0.Text = "0";
            btn0.Width = btnWidth;
            btn0.Height = btnHeight;
            btn0.Click += BtnNumero_Click;
            btn0.Location = new Point(btnMargin, 220);
            this.Controls.Add(btn0);

            Button btn1 = new Button();
            btn1.Name = "btn1";
            btn1.Text = "1";
            btn1.Width = btnWidth;
            btn1.Height = btnHeight;
            btn1.Click += BtnNumero_Click;
            btn1.Location = new Point(btnMargin, 165);
            this.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Name = "btn2";
            btn2.Text = "2";
            btn2.Width = btnWidth;
            btn2.Height = btnHeight;
            btn2.Click += BtnNumero_Click;
            btn2.Location = new Point(btnWidth + btnMargin * 2, 165);
            this.Controls.Add(btn2);
            Button btnSuma = new Button();
            btnSuma.Name = "btnSuma";
            btnSuma.Text = "+";
            btnSuma.Width = btnWidth;
            btnSuma.Height = btnHeight;
            btnSuma.Click += BtnOperacion_Click;
            btnSuma.Location = new Point(btnWidth * 3 + btnMargin * 4, 165);
            this.Controls.Add(btnSuma);
            Button btnIgual = new Button();
            btnIgual.Name = "btnIgual";
            btnIgual.Text = "=";
            btnIgual.Width = btnWidth;
            btnIgual.Height = btnHeight;
            btnIgual.Click += BtnIgual_Click;
            btnIgual.Location = new Point(btnWidth * 3 + btnMargin * 4, 220);
            this.Controls.Add(btnIgual);
            Button btnHistorial = new Button();
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Text = "Historial";
            btnHistorial.Width = btnWidth + btnWidth / 2;
            btnHistorial.Height = btnHeight;
            btnHistorial.Click += BtnHistorial_Click;
            btnHistorial.Location = new Point(btnMargin, 110);
            this.Controls.Add(btnHistorial);
            TextBox txtResultado = new TextBox();
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.TextAlign = HorizontalAlignment.Right;
            txtResultado.Width = btnWidth * 3 + btnMargin * 3;
            int textBoxHeight = 40;
            txtResultado.Height = textBoxHeight;
            txtResultado.Font = new Font("Arial", 16);
            txtResultado.Location = new Point(btnMargin, 50);
            this.Controls.Add(txtResultado);
            Label lblHistorial = new Label();
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Text = "Historial";
            lblHistorial.Font = new Font("Arial", 12, FontStyle.Bold);
            lblHistorial.AutoSize = true;
            lblHistorial.Location = new Point(btnMargin, 10);
            this.Controls.Add(lblHistorial);
            ListView lvHistorial = new ListView();
            lvHistorial.Name = "lvHistorial";
            lvHistorial.FullRowSelect = true;
            lvHistorial.Columns.Add("Operando 1", 80);
            lvHistorial.Columns.Add("Operando 2", 80);
            lvHistorial.Columns.Add("Operación", 80);
            lvHistorial.Columns.Add("Resultado", 80);
            lvHistorial.View = View.Details;
            lvHistorial.Height = textBoxHeight * 5;
            lvHistorial.Location = new Point(btnMargin, 50 + textBoxHeight + btnMargin);
            this.Controls.Add(lvHistorial);
        }

        private void BtnNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _entrada.Append(btn.Text);
            this.Controls.Find("txtResultado", true)[0].Text = _entrada.ToString();
        }

        private void BtnOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _operando1 = double.Parse(_entrada.ToString());
            _entrada.Clear();
            _operacion = btn.Text;
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            _operando2 = double.Parse(_entrada.ToString());
            _entrada.Clear();

            switch (_operacion)
            {
                case "+":
                    _resultado = _operando1 + _operando2;
                    break;


                default:
                    break;
            }

            this.Controls.Find("txtResultado", true)[0].Text = _resultado.ToString();

            

            _operando1 = _resultado;
            _operando2 = 0;
        }
        private void BtnHistorial_Click(object sender, EventArgs e)
        {
           // Create history window
            FormHistorial formHistorial = new FormHistorial();
            formHistorial.StartPosition = FormStartPosition.CenterParent;

            // Get history entries
            DataTable dtHistorial = ObtenerHistorial();

            // Add the entries to the ListView
            foreach (DataRow row in dtHistorial.Rows)
            {
                ListViewItem item = new ListViewItem(row["operando1"].ToString());
                item.SubItems.Add(row["operando2"].ToString());
                item.SubItems.Add(row["operacion"].ToString());
                item.SubItems.Add(row["resultado"].ToString());

                formHistorial.lvHistorial.Items.Add(item);
            }

            // Show the history window
            formHistorial.ShowDialog();
        }

        private DataTable ObtenerHistorial()
        {
            DataTable dtHistorial = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Calculadora;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Historial", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtHistorial);
            }
            return dtHistorial;
        }

                }

        private void BtnNumero_Click(object sender, EventArgs e)
        {
            Button btnNumero = (Button)sender;
            string numero = btnNumero.Text;

            // Get the corresponding operand according to the focus
            TextBox txtOperando = (txtOperando1.Focused) ? txtOperando1 : txtOperando2;

            // Add the number to the operand
            txtOperando.Text += numero;
        }

        private void BtnOperacion_Click(object sender, EventArgs e)
        {
            Button btnOperacion = (Button)sender;
            string operacion = btnOperacion.Text;

            // Select the corresponding operation
            switch (operacion)
            {
                case "+":
                    cmbOperacion.SelectedIndex = 0;
                    break;
                case "-":
                    cmbOperacion.SelectedIndex = 1;
                    break;
                case "x":
                    cmbOperacion.SelectedIndex = 2;
                    break;
                case "/":
                    cmbOperacion.SelectedIndex = 3;
                    break;
            }
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            double operando1 = double.Parse(txtOperando1.Text);
            double operando2 = double.Parse(txtOperando2.Text);
            double resultado = 0;

            // Get the corresponding operation
            switch (cmbOperacion.SelectedIndex)
            {
                case 0: // Add
                    resultado = operando1 + operando2;
                    break;
                case 1: // Subtraction
                    resultado = operando1 - operando2;
                    break;
                case 2: // Multiplication
                    resultado = operando1 * operando2;
                    break;
                case 3: // Division
                    if (operando2 == 0)
                    {
                        MessageBox.Show("No se puede dividir por cero");
                        return;
                    }
                    resultado = operando1 / operando2;
                    break;
            }

            // Display the result on the screen
            txtResultado.Text = resultado.ToString();

            // Add the corresponding record to the history and save it to the database
            string tipoOperacion = cmbOperacion.SelectedItem.ToString();
            string valores = $"{operando1} {tipoOperacion} {operando2}";
            AgregarRegistroHistorial(valores, tipoOperacion, resultado);
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
             // Create and display a new instance of the history window
            var historialWindow = new HistorialWindow();
            historialWindow.ShowDialog();
        }

        private void GuardarHistorial()
        {
            try
            {
                using (var conn = new SqlConnection(_conexionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Historial (Operando1, Operando2, Operacion, Resultado) VALUES (@operando1, @operando2, @operacion, @resultado)";
                        cmd.Parameters.AddWithValue("@operando1", _operando1);
                        cmd.Parameters.AddWithValue("@operando2", _operando2);
                        cmd.Parameters.AddWithValue("@operacion", _operacion);
                        cmd.Parameters.AddWithValue("@resultado", _resultado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el registro en el historial: {ex.Message}");
            }
        }
    }
