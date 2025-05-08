using AutoMapper;
using LibrarySystem.Api.Dtos.Book;
using LibrarySystem.Core.Entities;

namespace LibrarySystem.Api.Mapping
{
    public class BookMapping : Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookDto>()
                .ForMember(bookDto => bookDto.CategoryName, op => op.MapFrom(src => src.Category.Name));
            CreateMap<AddBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
