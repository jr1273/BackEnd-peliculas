using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;


namespace Peliculas_Api.Entidades
{
    public class Cine: IId
    {
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        public required string Nombre { get; set; }
        public required Point Ubicacion { get; set; }


    }
}
