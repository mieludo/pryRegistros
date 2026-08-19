using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
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
                if (Clientes[i].deuda > 0)
                {

                }
                dgvDatos.Rows.Add(Clientes[i].Codigo, Clientes[i].Usuario, Clientes[i].limite, Clientes[i].deuda);
                totalDeuda = totalDeuda + Clientes[i].deuda;
            }
            lblMonto.Text = totalDeuda.ToString();
        }


        private void frmRegistros_Load(object sender, EventArgs e)
        {
            btnCargar.Enabled = false;
            Precarga();
            Listar();
            ControlarCajas();
        }

        private void Precarga()
        {
            Clientes[ind].Codigo = 1;
            Clientes[ind].Usuario = "Joaquin";
            Clientes[ind].limite = 1000;
            Clientes[ind].deuda = 500;
            ind++;
            Clientes[ind].Codigo = 2;
            Clientes[ind].Usuario = "Franco";
            Clientes[ind].limite = 2000;
            Clientes[ind].deuda = 1000;
            ind++;
            Clientes[ind].Codigo = 3;
            Clientes[ind].Usuario = "Alegra";
            Clientes[ind].limite = 3000;
            Clientes[ind].deuda = 1500;
            ind++;
            Clientes[ind].Codigo = 4;
            Clientes[ind].Usuario = "Sofia";
            Clientes[ind].limite = 4000;
            Clientes[ind].deuda = 2000;
            ind++;
        }

        private void ControlarCajas()
        {
            if (txtCodigo.Text != "" && txtUsuario.Text != "" && txtLimite.Text != "" && txtDeuda.Text != "")
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }
        }



        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (ind < Clientes.Length)
            {
                int i = 0;
                while (Clientes[i].Codigo != Convert.ToInt32(txtCodigo.Text) && i < ind)
                {
                    i++;
                }
                if (i == ind)
                {
                    Clientes[ind].Codigo = Convert.ToInt32(txtCodigo.Text);
                    Clientes[ind].limite = Convert.ToDecimal(txtLimite.Text);
                    Clientes[ind].deuda = Convert.ToDecimal(txtDeuda.Text);
                    Clientes[ind].Usuario = txtUsuario.Text;
                    ind++;
                    //MessageBox.Show("Cliente cargado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.Text = "";
                    txtLimite.Text = "";
                    txtDeuda.Text = "";
                    txtUsuario.Text = "";
                    Listar();

                }
                else
                {
                    MessageBox.Show("El cliente ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No se pueden cargar más clientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Listar()
        {
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

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

        private void txtDeuda_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

        private void txtLimite_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }
    }
}


