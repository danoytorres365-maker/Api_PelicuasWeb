using AutoMapper;
using PeliculasApi5.Controllers;
using PeliculasApi5.Dtos;
using PeliculasApi5.Entidades;
using ActorPathDto = PeliculasApi5.Controllers.ActorPathDto;

namespace PeliculasApi5.helperts
{
    public class autoMapperProfiles:Profile // para que esta clase sea un perfil de automapper, heredamos de profile que viene de automapper


    {


       public autoMapperProfiles()
       {


            CreateMap<Genero, generoDto>().ReverseMap(); // le colocamos reverseMap porque tambien vamos 

            // a querer mapear desde GeneroDto a genero, ya que lo comun es heredar desde Genero hasta generoDto 


            CreateMap<GeneroCreacionDto,Genero>(); //voy a recibir un generoCreacionDto en mi metodo pos y quiero mapearlo hacia genero 


            CreateMap<Actor, ActorDto>().ReverseMap();


            CreateMap<ActorCreacionDto, Actor>().ReverseMap();

            //CreateMap<ActorPathDto, Actor>().ReverseMap();

            // CreateMap<Dtos.ActorPathDto, Actor>().ReverseMap();

            CreateMap<ActorPathDto, Actor>().ReverseMap();



        }

        



    }
}
