using Microsoft.Identity.Client;
using Peliculas_Api.Entidades;

namespace Peliculas_Api.DTOs
{
    public class ActorDTO : IId
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Foto { get; set; }
          

    }
}
