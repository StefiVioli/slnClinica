using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
    public static class AdmMedico
    {
        static DbClinicaContext context = new DbClinicaContext();

        public static List<Medico> Listar()
        {
            return context.Medicos.ToList();//retornamos todos los Medicos
        }

        public static List<Medico> ListarPorEspecialidad(int especialidadId)
        {
            //linq to entities
            List<Medico> medicos = (from m in context.Medicos
                                    where m.EspecialidadId == especialidadId
                                    select m).ToList();
            return medicos;

        }

        public static Medico TraerPorId(int id)
        {
            return context.Medicos.Find(id);
        }


        public static int Insertar(Medico Medico)
        {
            context.Medicos.Add(Medico);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }


        public static int Modificar(Medico Medico)
        {
            Medico MedicoOrigen = context.Medicos.Find(Medico.MedicoId);

            if (MedicoOrigen != null)
            {
                MedicoOrigen.Nombre = Medico.Nombre;
                MedicoOrigen.Apellido = Medico.Apellido;
                MedicoOrigen.Matricula = Medico.Matricula;
                MedicoOrigen.EspecialidadId = Medico.EspecialidadId;
                return context.SaveChanges();
            }
            return 0;
        }
        public static int Eliminar(int id)
        {
            Medico MedicoOrigen = context.Medicos.Find(id);
            if (MedicoOrigen != null)
            {
                context.Medicos.Remove(MedicoOrigen);
                return context.SaveChanges();
            }

            return 0;
        }


    }
}

