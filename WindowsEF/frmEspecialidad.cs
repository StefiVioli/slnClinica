using Datos.Admin;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsEF
{
    public partial class frmEspecialidad : Form
    {
        public frmEspecialidad()
        {
            InitializeComponent();
        }

        private void frmEspecialidad_Load(object sender, EventArgs e)
        {
            traerEspecialidades();
        }

        private void traerEspecialidades()
        {
            gridEspecialidades.DataSource = AdmEspecialidad.Listar();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad() { Nombre = txtNombre.Text };
            int filasAfectadas = AdmEspecialidad.Insertar(especialidad);
            if (filasAfectadas > 0)
            {
                traerEspecialidades();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad()
            {
                EspecialidadId = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
            };

            int filasAfectadas = AdmEspecialidad.Modificar(especialidad);

            if (filasAfectadas > 0)
            {
                traerEspecialidades();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            int filasAfectadas = AdmEspecialidad.Eliminar(id);
            if (filasAfectadas > 0)
            {
                traerEspecialidades();
            }
        }

        private void btnTraerTodas_Click(object sender, EventArgs e)
        {
            traerEspecialidades();
        }
    }
}
