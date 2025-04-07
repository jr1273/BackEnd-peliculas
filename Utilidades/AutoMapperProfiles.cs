using AutoMapper;
using Peliculas_Api.DTOs;
using Peliculas_Api.Entidades;

namespace Peliculas_Api.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            ConfigurarMapeoGeneros();
            ConfigurarMapeoActores();
        }

        private void ConfigurarMapeoActores()
        {
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto, opciones => opciones.Ignore());
           
        }
        private void ConfigurarMapeoGeneros()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<Genero, GeneroDTO>();
        }

    }
}
