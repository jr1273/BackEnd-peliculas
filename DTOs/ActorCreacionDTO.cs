using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class ActorCreacionDTO
    {
        [Required]
        [StringLength(150)]
        public required string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        
        public IFormFile? Foto { get; set; }

    }
}
