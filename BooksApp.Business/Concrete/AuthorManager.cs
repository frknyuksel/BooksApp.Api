using AutoMapper;
using BooksApp.Business.Abstract;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.Shared.DTOs;
using BooksApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorManager(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(Author author)
        {
            await _authorRepository.CreateAsync(author);
        }

        public async Task CreateWithUrl(Author author)
        {
            await _authorRepository.CreateWithUrl(author);
        }

        public void Delete(Author author)
        {
            _authorRepository.Delete(author);
        }

        public async Task<Response<List<AuthorDto>>> GetAllAsync()
        {
            var categoryList = await _authorRepository.GetAllAsync();
            if (!categoryList.Any())
            {
                return Response<List<AuthorDto>>.Fail("Yazar bulunamadı", 401);
            }
            var categoryListDto = _mapper.Map<List<AuthorDto>>(categoryList);
            return Response<List<AuthorDto>>.Success(categoryListDto, 200);
        }

        public async Task<List<Author>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null)
        {
            var result = await _authorRepository.GetAllAuthorsAsync(isDeleted,isActive);
            return result;
        }

        public async Task<Author> GetByIdAsync(int? id)
        {
            var result = await _authorRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
