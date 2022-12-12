using AutoMapper;
using MemeIT.Entities;
using MemeIT.Models;

namespace MemeIT.Mappers
{
    public class MemeMapper : Profile
    {
        public MemeMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Meme, MemeModel>().ReverseMap();
            CreateMap<ImageMemeModel,Meme>();
        } 
    }
}
