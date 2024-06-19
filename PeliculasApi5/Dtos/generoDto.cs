using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Dtos
{
    public class generoDto
    {

        // creamos un dto para no exponer nuestros datos al exterior 


        public int Id { get; set; }


        [Required]
        [StringLength(40)]
        public string nombre { get; set; }







    }
}
