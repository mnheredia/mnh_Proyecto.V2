using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mnh_Proyecto.V2.Models;

namespace mnh_Proyecto.V2.Context
{
    public class ClinicaDatabaseV2Context : DbContext

    {
        public ClinicaDatabaseV2Context(DbContextOptions<ClinicaDatabaseV2Context> options) : base(options)
        {
        }
        
        public DbSet<Medico> Medicos{ get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        
        //public DbSet<Mnh_ProyectoFinal.Models.TurnoConsultaMedica> TurnoConsultaMedica { get; set; }
        //public DbSet<Mnh_ProyectoFinal.Models.TurnoPracticaMedica> TurnoPracticaMedica { get; set; }

        //incluir turnos
        //cada entidad que quiera mapear a sql tengo que declarla acá


    }
}
