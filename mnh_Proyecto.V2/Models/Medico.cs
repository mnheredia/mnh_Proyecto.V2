using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public class Medico
    {
         
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public Especialidad especialidad { get; set; }
        
        /*
        [EnumDataType(typeof(Deporte))] //La especialidad de un medico pueden ser varias, puede tener una lista de especialidades
        public Deporte DeporteFavorito { get; set; }*/

    }
}
