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
        public ClinicaDatabaseV2Context()
        {
        }

        public ClinicaDatabaseV2Context(DbContextOptions<ClinicaDatabaseV2Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDBCF;Trusted_Connection=True;");
            //@"Server=DESKTOP-RRATHBU;Database=SchoolDBCF;Trusted_Connection=True;" es una Cadena de Conexión o Conction String
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RRATHBU;Database=ClinicaDatabaseV2;Trusted_Connection=True;");
        }


        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<mnh_Proyecto.V2.Models.TurnoConsultaMedica> TurnoConsultaMedica { get; set; }

        //public DbSet<Mnh_ProyectoFinal.Models.TurnoConsultaMedica> TurnoConsultaMedica { get; set; }
        public DbSet<TurnoPracticaMedica> TurnoPracticaMedica { get; set; }

        //incluir turnos
        //cada entidad que quiera mapear a sql tengo que declarla acá


    }
}
