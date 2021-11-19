using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public class TurnoConsultaMedica : Turno
    {
        public int IdMedico { get; set; }
        
    }
}
