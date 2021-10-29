using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
   
    [Table("Paciente")]//EF cuando crea la tabla la llama Paciente en singular sino por convensión pluraliza el nombre "Pacientes"
    public class Paciente
    {
        public int Id { get; set; }

        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Nombre { get; set; }

        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        public int NroHistoriaClinica { get; set; }

        public int MedicoId { get; set; }//FK clave externa

        //Propiedad de navegación
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

    }


}
