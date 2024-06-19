﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasApi5.Validaciones
{
    public class TipoArchivoValidacion : ValidationAttribute // validador generico para validar cualquier tipo de archivo

    {
        private readonly string[] tiposValidos;


        public TipoArchivoValidacion(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }


        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {

            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen)
            {

                tiposValidos = new string[] { "image/jpeg", "image/png", "image/gif" };


            }

        }
        


            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {



                    if(value == null)
                     {

                           return ValidationResult.Success;
                    

                      }

                    IFormFile formFile = value as IFormFile;



                    if(formFile == null)
                    {


                      return ValidationResult.Success;


                    }

            if (!tiposValidos.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo  del archivo debe ser uno de lo siguiente: {string.Join(",", tiposValidos)}");
            }

            return ValidationResult.Success;



             }
        
        





    }


    }

