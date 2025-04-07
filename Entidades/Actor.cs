﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Peliculas_Api.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]

        public required string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Unicode(false)]
        public string? Foto { get; set; }


    }
}
