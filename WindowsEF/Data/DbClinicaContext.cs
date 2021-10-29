using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //EF
using WindowsEF.Models;//ver los modelos


namespace WindowsEF.Data
{
   
    public class DbClinicaContext : DbContext
    {
        //constructor
        public DbClinicaContext() : base("KeyDbClinica") { }

        //propiedades DbSet<m>
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Medico> Medicos { get; set; }

    }
}


