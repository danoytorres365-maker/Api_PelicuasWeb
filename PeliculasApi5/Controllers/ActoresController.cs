using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi5.Dtos;
using PeliculasApi5.Entidades;

namespace PeliculasApi5.Controllers
{


    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public  ActoresController(ApplicationDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<List<ActorDto>>> Get()
        {


            var entidades = await context.Actores.ToListAsync();
            
            return mapper.Map<List<ActorDto>>(entidades);
        
        
        }


        //Obtener por id 

        [HttpGet("{id}", Name ="obtenerActor")]

        public async Task<ActionResult<ActorDto>> Get(int id) 
        
        {
        
            var entidad = await context.Actores.FirstOrDefaultAsync(x=> x.Id == id);

            
            if(entidad == null)
            {

                return NotFound("No encontrado");

            }

            return mapper.Map<ActorDto>(entidad);
        
        
        
        
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm]  ActorCreacionDto actorCreacionDto)  // utilizamos FromForm porque 

            // vamos a recibir un archivo que en este caso es una foto 
        
        {

            var entidad = mapper.Map<Actor>(actorCreacionDto);
            context.Add(entidad);
          //  await context.SaveChangesAsync();

            var dto = mapper.Map<ActorDto>(entidad);

            return new CreatedAtRouteResult("obtenerActor", new { id = entidad.Id }, dto);
        
        
        }

          
        [HttpPut("{id}")]

        public async Task<ActionResult> Put(int id, [FromForm] ActorCreacionDto actorCreacionDto) 
        
        {

            var entidad = mapper.Map<Actor>(actorCreacionDto);

            entidad.Id = id;

            context.Entry(entidad).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();

        
        
        }

        [HttpPatch("{id}")]

        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ActorPathDto> patchDocument)
        {


            if (patchDocument == null)
            {

                return BadRequest();

            }


            var entidadDb = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);


            if (entidadDb == null)


            {

                return NotFound();


            }

            var entidadDto = mapper.Map<ActorPathDto>(entidadDb);

            patchDocument.ApplyTo(entidadDto, ModelState);


            var esValido = TryValidateModel(entidadDto);


            if (!esValido)

            {

                return BadRequest(ModelState);

            }
             
            mapper.Map(entidadDto,entidadDb);

            await context.SaveChangesAsync();

            return NoContent();


        }








        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {

            var existe = await context.Actores.AnyAsync(x => x.Id == id);

            if (!existe)
            {

                return NotFound("Eto no existe");

            }

            context.Remove(new Actor() { Id = id });

            await context.SaveChangesAsync();


            return NoContent();

        }

    }

    public class ActorPathDto
    {
    }
}
