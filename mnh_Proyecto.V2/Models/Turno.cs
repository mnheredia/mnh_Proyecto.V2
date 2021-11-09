using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public DiasDisponibles DiasDisponibles { get; set; }
        public HorasDisponibles HorasDisponibles { get; set; }

        //tipo prestacion, tipo turno, consulta, practica medica, capturaqr el onclick, al momento del create ver los parámetros verl el valor del tipo de turno, y redirigir en base.
        // public TipoTurno? ver si puede recibir por parámetro un Medico o un Estudio. O ver si tengo que hacer dos tipos de turnos diferentes
        //ver si se pueden fragmentar por hora los horarios de turnos. asignación de turnos por array cantidad fija, dividirlo por horas

        //voy a empezar a hacer la lógica de la creación de turno primero desde una especialidad hasta el médico
        //mapear a la bbdd
    }
}
