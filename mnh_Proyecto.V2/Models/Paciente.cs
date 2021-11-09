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
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string ObraSocial { get; set; }
        public int NroAfiliado { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }


    }
}
