using Peliculas_Api.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class GeneroDTO
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }

    }
}
