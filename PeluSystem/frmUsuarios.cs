using System;
using System.Windows.Forms;

namespace PeluSystem
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaUsuario f = new frmAltaUsuario();
            f.MdiParent = this.MdiParent;
            f.ID = 0;
            f.Show();
            f.Left = (this.Left + this.Width - f.Width) / 2;
            f.Top = (this.Top + this.Height - f.Height) / 2;
            f.FormClosed += F_FormClosed;
        }

        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarUsuarios();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            APP.appUsuario usuario = new APP.appUsuario();
            DBUsuarios.DataSource = usuario.Traer();
            usuario = null;
        }

        private int ObtenerIdSeleccionado()
        {
            if (DBUsuarios.CurrentRow != null)
            {
                return int.Parse(DBUsuarios.Rows[DBUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
            }
            return 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = ObtenerIdSeleccionado();
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAltaUsuario f = new frmAltaUsuario();
            f.MdiParent = this.MdiParent;
            f.ID = idSeleccionado;
            f.Show();
            f.Left = (this.Left + this.Width - f.Width) / 2;
            f.Top = (this.Top + this.Height - f.Height) / 2;
            f.FormClosed += F_FormClosed;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = ObtenerIdSeleccionado();
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    APP.appUsuario app = new APP.appUsuario();
                    app.Eliminar(idSeleccionado);
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}