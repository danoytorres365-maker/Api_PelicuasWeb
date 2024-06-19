using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Validaciones
{
    public class PesoArchivoValidacion:ValidationAttribute

    {
        private readonly int pesoMaximoEnMegaBytes;

        public PesoArchivoValidacion(int PesoMaximoEnMegaBytes) // constructor
        {
            pesoMaximoEnMegaBytes = PesoMaximoEnMegaBytes;
        }

         // Personalizacion de validacion de archivos 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           

            if (value == null)
            {

                return ValidationResult.Success;

            }

            IFormFile formFile = value as IFormFile;

            if(formFile == null)
            {

                return ValidationResult.Success;


            }


            if(formFile.Length > pesoMaximoEnMegaBytes *1024 *1024)
            {


                return new ValidationResult($"El peso del archivo es muyt grande no debe ser mayor a {pesoMaximoEnMegaBytes} mb");


            }

            return ValidationResult.Success;

        }


    }
}
