using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi5.Dtos;
using PeliculasApi5.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace PeliculasApi5.Controllers
{

    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase // heredando la clase controllerBase, para obtener controladores
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper) // constructor para inyectar una instancia del applicationDbcontext para poder tener acceso a EntityFramework desde este controlador


        {
            //IMapper mapper : Inyectando el servicio de autoMapper ,seguido del namespace




            this.context = context; // para generar esto solo colocamos control + .punto 
            this.mapper = mapper;

            //Generamos esto para tener acceso a este contexto desde cualaquier metodo o controlador 
            // 


        }


        [HttpGet]

        public async Task<ActionResult<List<generoDto>>> Get()
        {


    
                     var entidades = await context.Generos.ToListAsync();

                     var dtos = mapper.Map<List<generoDto>>(entidades);

                     return dtos;
            
        
        }

        [HttpGet("{id:int}", Name ="obtenerGenero")]
        public async Task<ActionResult<generoDto>> Get(int id)
        {

            var entidad = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null)
            {

                return NotFound();

            }

            var dto = mapper.Map<generoDto>(entidad);
            return dto;

        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] GeneroCreacionDto generoCreacionDto)   // Con FromBody le decimos que desde el cuerpo
                                                                             // de la peticion http. queremos sacar la siguiente info. 
        {

            var entidad = mapper.Map<Genero>(generoCreacionDto);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var generoDto = mapper.Map<generoDto>(entidad);

            return new CreatedAtRouteResult("obtenerGenero", new { Id = generoDto.Id }, generoDto);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDto generoCreacionDto)
        {

            var entidad = mapper.Map<Genero>(generoCreacionDto);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified; // indicandole que esta entidad ha sido modificada

            await context.SaveChangesAsync();
            return NoContent();
                

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {

            var existe = await context.Generos.AnyAsync(x => x.Id == id);

            if (!existe)
            {

                return NotFound();

            }

            context.Remove(new Genero() { Id = id });

            await context.SaveChangesAsync();


            return NoContent();

        }



    }
}
