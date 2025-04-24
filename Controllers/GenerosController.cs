

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Peliculas_Api.DTOs;
using Peliculas_Api.Entidades;
using Peliculas_Api.Utilidades;
using System.Threading.Tasks;


namespace Peliculas_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController: CustomBaseController
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "generos";

        public GenerosController(IOutputCacheStore outputCacheStore, ApplicationDbContext context,
            IMapper mapper)
            : base(context, mapper, outputCacheStore, cacheTag)
        {
            this.outputCacheStore =  outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }



        [HttpGet]
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<GeneroDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            return await Get<Genero, GeneroDTO>(paginacion, ordenarPor: g => g.Nombre);

        }


        [HttpGet ("{id:int}", Name = "ObtenerGeneroporId")] //api/generos
        [OutputCache(Tags = [cacheTag])]
        public  async  Task <ActionResult<GeneroDTO>> Get(int id )
        {
            return await Get<Genero, GeneroDTO>(id);
        
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneroCreacionDTO  generoCreacionDTO)
        {
            return await Post<GeneroCreacionDTO, Genero, GeneroDTO>(generoCreacionDTO, "obtenerPorId");
        }


        [HttpPut ("{id:int}")]
        public   async Task<IActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO) 
        {
            return await Put<GeneroCreacionDTO, Genero>(id, generoCreacionDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await Delete<Genero>(id);
        }    
    }
}
