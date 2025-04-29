
using AutoMapper;
namespace UserTests.models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test, TestResponseDto>();
            CreateMap<Question, QuestionResponseDto>();
            CreateMap<Option, OptionResponseDto>();
        }
    }
}