
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Peliculas_Api.Entidades;
using System.Threading.Tasks;


namespace Peliculas_Api.Controllers
{
    [Route("api/[controller]")]
    public class GenerosController: ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private const string cacheTg = "genero";

        public GenerosController(IOutputCacheStore outputCacheStore, ApplicationDbContext context)
        {
            this.outputCacheStore =  outputCacheStore;
            this.context = context;
        }



        [HttpGet]
        [OutputCache(Tags = [cacheTg])]
        public List<Genero> Get()
        {   
            return new List<Genero>() { new Genero { Id= 1, Nombre = "comedia"},
                new Genero { Id =2, Nombre = "accion"} };
        }

        [HttpGet ("{id:int}", Name = "ObtenerGeneroporId")] //api/generos
        [OutputCache(Tags = [cacheTg])]
        public  async  Task <ActionResult<Genero>> Get(int id )
        {

            throw new NotImplementedException();
        
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerGeneroporId", new { id = genero.Id }, genero);
        }


        [HttpPut]
        public void Put() 
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public void Delete()
        {
            throw new NotImplementedException();
        }    
    }
}
