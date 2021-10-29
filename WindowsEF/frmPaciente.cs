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
    public partial class frmPaciente : Form
    {
        public frmPaciente()
        {
            InitializeComponent();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            traerPacientes();

        }

        private void traerPacientes()
        {
            gridPacientes.DataSource = AdmPaciente.Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente() { Nombre = "Ana", Apellido = "Fernandez", FechaNacimiento = new DateTime(2000, 1, 20), NroHistoriaClinica = 1111, MedicoId = 1 };

            int filasAfectadas = AdmPaciente.Insertar(paciente);
            if (filasAfectadas > 0)
            {
                traerPacientes();

            }

        }
    }
}
