﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static mnh_Proyecto.V2.Models.Validations;

namespace mnh_Proyecto.V2.Models
{
    public class TurnoConsultaMedica : Turno
    {
        public int IdMedico { get; set; }
        public string FechaConsultaMedica { get; set; }

        //[Required(ErrorMessage = "El campo no puede quedar vacío")]
        //[Range(90000, 100000000, ErrorMessage = "El documento debe tener al menos 6 caracteres y como máximo 9")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "El documento solo debe contener números")]
        [DniExistsDB]
        public int DocumentoPaciente { get; set; }

    }
}
