using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Dtos
{
    public class ActorPathDto
    {



        [Required] 

        [StringLength(120)] 

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }


    }
}
