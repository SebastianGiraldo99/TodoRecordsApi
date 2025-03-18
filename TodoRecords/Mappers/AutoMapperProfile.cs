using AutoMapper;
using TodoRecords.Domain.DTOs;
using TodoRecords.Domain.Models;

namespace TodoRecords.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CrearTodoDTO, TodoModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.DeleteAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ReverseMap();

            CreateMap<UpdateTodoDTO, TodoModel>()
                .ForMember(dest => dest.IdTodo, opt => opt.MapFrom(src => src.idTodo))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ReverseMap();
        }
    }
}
