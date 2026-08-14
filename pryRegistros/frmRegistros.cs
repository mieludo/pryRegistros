using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRegistros
{
    public partial class frmRegistros : Form
    {
        public frmRegistros()
        {
            InitializeComponent();
        }
        //Declaración del registro de clientes
        private struct RegCliente
        {
            public string Usuario;
            public int Codigo;
            public decimal limite;
            public decimal deuda;
        };
        //Declaración del vector
        private RegCliente[] Clientes = new RegCliente[10];

        //Declaración del indice
        private int ind = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            decimal totalDeuda = 0;
            dgvDatos.Rows.Clear();
            for (int i = 0; i < ind; i++)
            {
                dgvDatos.Rows.Add(Clientes[i].Codigo, Clientes[i].Usuario, Clientes[i].limite, Clientes[i].deuda);
                totalDeuda = totalDeuda + Clientes[i].deuda;
            }
            lblMonto.Text = totalDeuda.ToString();
        }


        private void frmRegistros_Load(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (ind < Clientes.Length)
            {
                Clientes[ind].Codigo = Convert.ToInt32(txtCodigo.Text);
                Clientes[ind].limite = Convert.ToDecimal(txtLimite.Text);
                Clientes[ind].deuda = Convert.ToDecimal(txtDeuda.Text);
                Clientes[ind].Usuario = txtUsuario.Text;
                ind++;
                MessageBox.Show("Cliente cargado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = "";
                txtLimite.Text = "";
                txtDeuda.Text = "";
                txtUsuario.Text = "";

            }
            else
            {
                MessageBox.Show("No se pueden cargar más clientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}


