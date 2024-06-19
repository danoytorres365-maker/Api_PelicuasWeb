using PeliculasApi5.Controllers;
using PeliculasApi5.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Dtos
{
    public class ActorCreacionDto:ActorPathDto  // Heredando de ActorPathDto las caracteristicas 
    {



       
        [PesoArchivoValidacion(4)]
        [TipoArchivoValidacion(grupoTipoArchivo:GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set;} // Con IFormFile guardamos archivos 



    }
}
