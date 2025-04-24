﻿namespace Peliculas_Api.DTOs
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Trailer { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string? Poster { get; set; }
    }
}