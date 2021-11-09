using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public class Paciente
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(9), MinLength(6)]
        [Required(ErrorMessage = "El documento debe tener entre 6 y 9 caracteres")]
        public int Documento { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres"), MaxLength(30), MinLength(3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El apellido debe tener entre 3 y 30 caracteres"), MaxLength(30), MinLength(3)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La obra social debe tener entre 6 y 15 caracteres"), MaxLength(15), MinLength(6)]
        [Display(Name = "Obra Social")]
        public string ObraSocial { get; set; }

        [MaxLength(11), MinLength(6)]
        [Required(ErrorMessage = "El número de afiliado debe tener entre 6 y 11 caracteres")]
        public int NroAfiliado { get; set; }

        [Required(ErrorMessage = "Teléfono de Contacto inválido")]
        [Display(Name = "Telefono de Contacto")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email inválido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Email no es válido.")]
        public string CorreoElectronico { get; set; }


    }
}
