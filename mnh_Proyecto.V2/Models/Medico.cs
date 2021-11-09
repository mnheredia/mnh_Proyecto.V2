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

        [MaxLength(7), MinLength(5)]
        [Required(ErrorMessage = "La matrícula debe tener entre 5 y 7 caracteres")]
        public int Matricula { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres"), MaxLength(30), MinLength(3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El apellido debe tener entre 3 y 30 caracteres"), MaxLength(30), MinLength(3)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        public Especialidad Especialidad { get; set; }
        
        
        /*
        [EnumDataType(typeof(Deporte))] //La especialidad de un medico pueden ser varias, puede tener una lista de especialidades
        public Deporte DeporteFavorito { get; set; }*/

    }
}
