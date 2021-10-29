using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{  
    
    [Table("Clinica")]
    public class Clinica
    {
        public int Id { get; set; }

        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 

        public string Nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicioActividades { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
    }
   
    }

