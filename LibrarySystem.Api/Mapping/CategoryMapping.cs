using AutoMapper;
using LibrarySystem.Api.Dtos.Book;
using LibrarySystem.Api.Dtos.Category;
using LibrarySystem.Core.Entities;

namespace LibrarySystem.Api.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateBookDto, Book>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
