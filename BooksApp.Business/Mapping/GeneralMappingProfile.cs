using AutoMapper;
using BooksApp.Entity.Concrete;
using BooksApp.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Mapping
{
    public class GeneralMappingProfile:Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();

            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Publisher, PublisherCreateDto>().ReverseMap();

            CreateMap<Book, BookDto>()
                .ForMember(x=>x.Categories, opt=>opt.MapFrom(x=>x.BookCategories.Select(x=>x.Category)))
                .ReverseMap();

            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();

            CreateMap<Author, AuthorDto>().ReverseMap();



        }
    }
}
