using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Gestion_Ferreteria.Formularios.Presupuesto
{
    public partial class frmAltaPresupuesto : Form
    {
        public frmAltaPresupuesto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desea cancelar el nuevo presupuesto?",
                "Atencion",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if(resultado == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
