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
    public partial class frmMedico : Form
    {
        public frmMedico()
        {
            InitializeComponent();
        }

        private void frmMedico_Load(object sender, EventArgs e)
        {
            traerMedicos();
            llenarComboEspecialidad();
            llenarComboEspecialidadBuscar();
        }

        private void llenarComboEspecialidadBuscar()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            especialidades.Insert(0,new Especialidad() { EspecialidadId=0, Nombre= "[TODAS]" });
            cbBuscarPorEspecialidad.DataSource = especialidades;
            cbBuscarPorEspecialidad.DisplayMember = "Nombre";
            cbBuscarPorEspecialidad.ValueMember = "EspecialidadId";
        }

        private void llenarComboEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.DisplayMember = "Nombre";
            cbEspecialidad.ValueMember = "EspecialidadId";

        }
        private void traerMedicos()
        {
            gridMedicos.DataSource = AdmMedico.Listar();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Matricula = Convert.ToInt32(txtMatricula.Text), EspecialidadId =Convert.ToInt32(cbEspecialidad.SelectedValue)};
            int filasAfectadas = AdmMedico.Insertar(medico);
            if (filasAfectadas > 0)
            {
                traerMedicos();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            int filasAfectadas = AdmMedico.Eliminar(id);
            if (filasAfectadas > 0)
            {
                traerMedicos();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico()
            {
                MedicoId = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                EspecialidadId = Convert.ToInt32(cbEspecialidad.SelectedValue)

            };

            int filasAfectadas = AdmMedico.Modificar(medico);

            if (filasAfectadas > 0)
            {
                traerMedicos();
            }

        }

        private void cbBuscarPorEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //el SelectedValue captura el id "ValueMember"
            int especialidad = Convert.ToInt32(cbBuscarPorEspecialidad.SelectedValue);

            gridMedicos.DataSource = AdmMedico.Listar();
            if (especialidad == 0)
            {
                traerMedicos();
            }
            else
            {
                gridMedicos.DataSource = AdmMedico.ListarPorEspecialidad(especialidad);
            }

        }
    }
}
