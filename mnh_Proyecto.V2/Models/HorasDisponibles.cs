using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public enum HorasDisponibles
    {
        [Display(Name = "08:00")]
        Ocho,
        [Display(Name = "09:00")]
        Nueve,
        [Display(Name = "10:00")]
        Diez,
        [Display(Name = "11:00")]
        Once,
        [Display(Name = "12:00")]
        Doce,
        [Display(Name = "13:00")]
        Trece
    }
}
