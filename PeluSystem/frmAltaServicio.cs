using System;
using System.Windows.Forms;
using DOM;
using APP;

namespace PeluSystem
{
    public partial class frmAltaServicio : Form
    {
        public frmAltaServicio()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var servicioService = new ServicioService();
            var nuevoServicio = new Servicio
            {
                Nombre = txtNombre.Text,
                Precio = numPrecio.Value
            };

            bool guardado = servicioService.GuardarServicio(nuevoServicio);

            if (guardado)
            {
                MessageBox.Show("Servicio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}