using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.Validaciones
{
    public class PrimeraLetraMayusculaAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if ( value is null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var PrimeraLetra = value.ToString()![0] .ToString();
            if(PrimeraLetra != PrimeraLetra.ToUpper())
            {
                return new ValidationResult("la primera letra debe ser mayuscula");

            }
            return ValidationResult.Success;
        }
    }
    

    
}
