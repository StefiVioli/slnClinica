using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }
       
        //propiedad de navegación
        public List<Paciente> Pacientes { get; set; }

       //FK clave externa
        public int EspecialidadId { get; set; }
        //Propiedad de navegación
        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }


    }

}
