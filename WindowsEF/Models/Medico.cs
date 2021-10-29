using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }

        //propiedad de navegación
        public List<Paciente> Pacientes { get; set; }

        public List<Especialidad> Especialidades { get; set; }

    }

}
