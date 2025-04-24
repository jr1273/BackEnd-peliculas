using Peliculas_Api.Entidades;
using Peliculas_Api.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.DTOs
{
    public class GeneroDTO : IId
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }

    }
}
