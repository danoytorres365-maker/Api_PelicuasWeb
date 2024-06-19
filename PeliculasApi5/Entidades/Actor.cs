using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Entidades
{
    public class Actor
    {


                    
        public int Id { get; set; }
        [Required]

        [StringLength(20)]

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Foto { get; set; } // aqui vamos a guardar la url de la foto 






    }
}
