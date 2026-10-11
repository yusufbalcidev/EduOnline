using AutoMapper;
using EduOnline.DTO.DTOs.AboutDtos;
using EduOnline.Entity.Entities;

namespace EduOnline.Api.Mapping
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateDto, About>().ReverseMap();
            CreateMap<UpdateDto, About>().ReverseMap();
        }
    }
}
