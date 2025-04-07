

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
    public class GenerosController: ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private const string cacheTg = "generos";

        public GenerosController(IOutputCacheStore outputCacheStore, ApplicationDbContext context,
            IMapper mapper)
        {
            this.outputCacheStore =  outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }



        [HttpGet]
        [OutputCache(Tags = [cacheTg])]
        public async Task< List<GeneroDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = context.Generos;
            await HttpContext.InsertarParametroPaginacionEnCabecera(queryable);
            
         return await queryable
                .OrderBy(g => g.Nombre)
             .Paginar(paginacion)   
                .ProjectTo<GeneroDTO>(mapper.ConfigurationProvider).ToListAsync(); 
        }

        [HttpGet ("{id:int}", Name = "ObtenerGeneroporId")] //api/generos
        [OutputCache(Tags = [cacheTg])]
        public  async  Task <ActionResult<GeneroDTO>> Get(int id )
        {
            var genero = await context.Generos
                .ProjectTo<GeneroDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(g => g.Id == id);
            
           if (genero is null)
            {
                return NotFound();
            }
            return genero;
        
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneroCreacionDTO  generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTg, default);
            return CreatedAtRoute("ObtenerGeneroporId", new {id = genero.Id },genero);
        }


        [HttpPut ("{id:int}")]
        public   async Task<IActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO) 
        {
            var generoExiste = await context.Generos.AnyAsync(g => g.Id == id);
            if (!generoExiste)
            {
                return NotFound();
            }
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            genero.Id = id;
            context.Update(genero);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTg, default);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();
             if (registrosBorrados ==0)
            {
                return NotFound();
            }
            await outputCacheStore.EvictByTagAsync(cacheTg, default);
            return NoContent();
        }    
    }
}
