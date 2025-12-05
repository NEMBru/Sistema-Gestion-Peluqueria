using System;
using System.Windows.Forms;
using APP;

namespace PeluSystem
{
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void CargarServicios()
        {
            var servicioService = new ServicioService();
            dgvServicios.AutoGenerateColumns = true;
            dgvServicios.DataSource = servicioService.ObtenerTodosLosServicios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmAltaServicio();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            frm.FormClosed += Frm_FormClosed;
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarServicios();
        }
    }
}