using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Gestion_Ferreteria
{
    public partial class frmIngreso : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        public frmIngreso()
        {
            InitializeComponent();
            conexion = new SqlConnection();
            comando = new SqlCommand();
            conexion.ConnectionString = Properties.Resources.cadenaConexion;
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea cancelar el ingreso de productos?", "Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "";
                conexion.Close();
            }
        }

        private bool Validar()
        {
            bool resultado = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.", "Atencion");
                resultado = false;
            }
            foreach (char c in txtNombre.Text)
            {
                if(char.IsDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    MessageBox.Show("Solo pueden ingresar letras.", "Atencion");
                    resultado = false;
                    break;
                }
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Debe ingresar numeros.", "Atencion");
                resultado = false;
            }
            foreach (char c in txtPrecio.Text)
            {
                if (!char.IsDigit(c) && c != '.'  )
                {
                    MessageBox.Show("Solo se puede ingresar numeros o punto", "Atencion");
                    resultado = false;
                    break;
                }
            }
            return resultado;
        }
    }
}
