using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public enum TipoEstudio
    {
        Laboratorio,
        ResonanciaMagnetica,
        Ecografía,
        Mamografía,
        Radiología,
        Tomografía
        
    }
}
