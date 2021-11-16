using mnh_Proyecto.V2.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mnh_Proyecto.V2.Models
{
    public class Validations
    {
        public class DniExistsAtributte : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using (var context = new ClinicaDatabaseV2Context())
                {
                    int Dni = (int)value;
                    if (context.Pacientes.Any(e => e.Documento == Dni)) //probar usando any
                    {
                        return new ValidationResult("El usuario ya está registrado en el sistema");
                    }
                }
                return ValidationResult.Success;
            }
        }


        public class MatriculaExistsAtributte : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using (var context = new ClinicaDatabaseV2Context())
                {
                    int Matricula = (int)value;
                    if (context.Medicos.Any(e => e.Matricula == Matricula)) 
                    {
                        return new ValidationResult("El médico ya está registrado en el sistema");
                    }
                }
                return ValidationResult.Success;
            }
        }


        public class ValidDateAtributte : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                    DateTime fechaIngresada = (DateTime)value;
                    DateTime date = DateTime.Now;
                    if (fechaIngresada > date) 
                    {
                        return new ValidationResult("La fecha de nacimiento no puede ser mayor al día actual");
                    }
                return ValidationResult.Success;
            }
        }


    }
}
