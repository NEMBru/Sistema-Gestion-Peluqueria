using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluSystem
{
    public partial class PeluqueriaSystem : Form
    {
        public PeluqueriaSystem()
        {
            InitializeComponent();
        }

        private void PeluqueriaSystem_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios f = new frmUsuarios();
            f.MdiParent = this;
            f.Show();
            f.Left = (this.Left + this.Width - f.Width) / 2;
            f.Top = (this.Top + this.Height - f.Height) / 2;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes f = new frmClientes();
            f.MdiParent = this;
            f.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicios f = new frmServicios();
            f.MdiParent = this;
            f.Show();
        }
    }
}