using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    [Table("Especialidad")]
    public class Especialidad
    {
        [Key]
        public int EspecialidadId { get; set; }

        
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Nombre { get; set; }

        public int MedicoId { get; set; }//FK clave externa

        //Propiedad de navegación
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

    }
}
