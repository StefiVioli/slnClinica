using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }

        public int Numero { get; set; }

        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(6)]
        public string Estado { get; set; }

        public int Id { get; set; }//FK clave externa

        //Propiedad de navegación
        [ForeignKey("Id")]
        public Clinica Clinica { get; set; }

    }

}
