using Microsoft.OpenApi.MicrosoftExtensions;
using Peliculas_Api.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.Entidades
{
    public class Genero : IId
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es requerido")]
        [StringLength(50, ErrorMessage = " el campo{0}  debe tener {1} caracter o menos")]
        [PrimeraLetraMayuscula]
        public  required string Nombre { get; set; }
      
    }
}
