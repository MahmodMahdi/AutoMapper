using AutoMapper.Demo.Dtos;
using AutoMapper.Demo.Models;

namespace AutoMapper.Demo
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
                // this step when the Prob in source Class not equal the same Prob in destination class
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.BookId))
                 .ForMember(dest => dest.IsFree, src => src.MapFrom(src => src.Price == 0))  // here i can add any condition i need to mapping
                 .ReverseMap();

		}
	}
}
