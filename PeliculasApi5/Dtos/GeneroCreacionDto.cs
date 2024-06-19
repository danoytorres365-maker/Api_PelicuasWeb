using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Dtos
{
    public class GeneroCreacionDto
    {


        [Required]
        [StringLength(40)]
        public string nombre { get; set; }



    }
}
