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
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public BookManager(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<Response<BookDto>> CreateAsync(BookCreateDto bookCreateDto)
        {
            var newBook = _mapper.Map<Book>(bookCreateDto);
            newBook.CreatedDate = DateTime.Now;
            newBook.Author =await _authorRepository.GetByIdAsync(newBook.AuthorId);
            newBook.Publisher =await _publisherRepository.GetByIdAsync(newBook.PublisherId);
            await _bookRepository.CreateAsync(newBook);

            return Response<BookDto>.Success(_mapper.Map<BookDto>(newBook), 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var deletedBook = await _bookRepository.GetByIdAsync(id);
            if (deletedBook == null)
            {
                return Response<NoContent>.Fail("Böyle bir kitap yok", 401);
            }
            _bookRepository.Delete(deletedBook);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<BookDto>>> GetAllAsync()
        {
            var bookList = await _bookRepository.GetAllAsync();
            if (bookList.Any())
            {
                foreach (var book in bookList)
                {
                    book.Author = await _authorRepository.GetByIdAsync(book.AuthorId);
                    book.Publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
                }

                var bookDtoList = _mapper.Map<List<BookDto>>(bookList);
                return Response<List<BookDto>>.Success(bookDtoList, 200);
            }
            return Response<List<BookDto>>.Fail("Kayıtlı kitap bulunamadı", 401);
        }

        public async Task<Response<BookDto>> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                book.Author = await _authorRepository.GetByIdAsync(book.AuthorId);
                book.Publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);

                var bookDto = _mapper.Map<BookDto>(book);
                return Response<BookDto>.Success(bookDto, 200);
            }
            return Response<BookDto>.Fail("Kitap bulunamadı", 401);
        }

        public async Task<Response<NoContent>> UpdateAsync(BookUpdateDto bookUpdateDto)
        {
            var isThere = await _bookRepository.AnyAsync(bookUpdateDto.Id);
            if (isThere)
            {
                var book = _mapper.Map<Book>(bookUpdateDto);
                book.ModifiedDate = DateTime.Now;
                _bookRepository.Update(book);
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Böyle bir kitap bulunamadı", 401);
        }

        public async Task<Response<List<BookDto>>> GetBooksWithFullDataAsync(bool? isHome = null, bool? isActive = null)
        {
            var bookList = await _bookRepository.GetBooksWithFullDataAsync(isHome, isActive);
            if (bookList.Any())
            {
                var bookDtoList = _mapper.Map<List<BookDto>>(bookList);
                return Response<List<BookDto>>.Success(bookDtoList, 200);
            }
            return Response<List<BookDto>>.Fail("Kayıtlı kitap bulunamadı", 401);
        }

        public async Task<Response<List<BookDto>>> GetAllActiveBooksAsync(string categoryUrl = null, string authorUrl = null, string publisherUrl = null)
        {
            var bookList = await _bookRepository.GetAllActiveBooksAsync(categoryUrl, authorUrl, publisherUrl);
            if (bookList.Any())
            {
                var bookDtoList = _mapper.Map<List<BookDto>>(bookList);
                return Response<List<BookDto>>.Success(bookDtoList, 200);
            }
            return Response<List<BookDto>>.Fail("Kayıtlı kitap bulunamadı", 401);
        }

        public async Task<Response<BookDto>> GetBookByUrlAsync(string bookUrl)
        {
            var book = await _bookRepository.GetBookByUrlAsync(bookUrl);
            if (book!=null)
            {
                var bookDto = _mapper.Map<BookDto>(book);
                return Response<BookDto>.Success(bookDto, 200);
            }
            return Response<BookDto>.Fail("Böyle bir kitap bulunamadı", 401);

        }

        public async Task<Response<List<BookDto>>> GetAllBooksWithAuthorAndPublisher(bool isDeleted)
        {
            var bookList = await _bookRepository.GetAllBooksWithAuthorAndPublisher(isDeleted);
            if (bookList.Any())
            {
                var bookDtoList = _mapper.Map<List<BookDto>>(bookList);
                return Response<List<BookDto>>.Success(bookDtoList, 200);
            }
            return Response<List<BookDto>>.Fail("Kayıtlı kitap bulunamadı", 401);
        }

        public async Task CreateBookAsync(Book book, List<int> SelectedCategoryIds)
        {
            await _bookRepository.CreateBookAsync(book, SelectedCategoryIds);
        }

        public async Task<Response<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book != null)
            {
                var bookDto = _mapper.Map<BookDto>(book);
                return Response<BookDto>.Success(bookDto, 200);
            }
            return Response<BookDto>.Fail("Kitap bulunamadı", 401);
        }

        public async Task UpdateAuthorOfBooks()
        {
            await _bookRepository.UpdateAuthorOfBooks();
        }

        public async Task UpdatePublisherOfBooks()
        {
            await _bookRepository.UpdatePublisherOfBooks();
        }

        public async Task CheckBooksCategories()
        {
            await _bookRepository.CheckBooksCategories();
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public async Task<Response<List<BookDto>>> GetBooksByCategoryAsync(int categoryId)
        {
            var bookList = await _bookRepository.GetBooksByCategoryAsync(categoryId);
            if (bookList.Any())
            {
                var bookDtoList = _mapper.Map<List<BookDto>>(bookList);
                return Response<List<BookDto>>.Success(bookDtoList, 200);
            }
            return Response<List<BookDto>>.Fail("Bu kategoride kitap bulunamadı", 401);
        }
    }
}
