using System;
using System.Windows.Forms;
using APP;

namespace PeluSystem
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }



        private void CargarClientes()
        {
            var clienteService = new ClienteService();
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = clienteService.ObtenerTodosLosClientes();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmAltaCliente();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            frm.FormClosed += Frm_FormClosed;
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarClientes();
        }
    }
}