using System;
using System.Windows.Forms;
using DOM;
using APP;

namespace PeluSystem
{
    public partial class frmAltaUsuario : Form
    {
        public int ID { get; set; }
        private APP.appUsuario app = new APP.appUsuario();

        public frmAltaUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = new DOM.domUsuario();
                usuario.Apellido = txtApellido.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Email = txtEmail.Text;
                usuario.Clave = txtClave.Text;
                usuario.Estado = chkEstado.Checked ? 1 : 0;
                usuario.Rol = cboRol.SelectedIndex + 1;

                if (this.ID == 0)
                {
                    app.Agregar(usuario);
                    MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    usuario.ID = this.ID;
                    app.Modificar(usuario);
                    MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAltaUsuario_Load(object sender, EventArgs e)
        {
            cboRol.Items.Add("Administrador");
            cboRol.Items.Add("Empleado");
            cboRol.Items.Add("Peluquero");

            if (this.ID == 0)
            {
                this.Text = "Alta de Usuario";
                btnGuardar.Text = "Guardar";
                cboRol.SelectedIndex = 0;
                chkEstado.Checked = true;
            }
            else
            {
                this.Text = "Modificar Usuario";
                btnGuardar.Text = "Actualizar";
                CargarDatosDeUsuario();
            }
        }

        private void CargarDatosDeUsuario()
        {
            try
            {
                var u = app.Traer(this.ID);
                if (u != null)
                {
                    txtID.Text = u.ID.ToString();
                    txtApellido.Text = u.Apellido;
                    txtNombre.Text = u.Nombre;
                    txtEmail.Text = u.Email;
                    txtClave.Text = u.Clave;
                    chkEstado.Checked = (u.Estado == 1);
                    if (u.Rol > 0 && u.Rol <= cboRol.Items.Count)
                    {
                        cboRol.SelectedIndex = u.Rol - 1;
                    }
                    else
                    {
                        cboRol.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}