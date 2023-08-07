using BooksApp.Entity.Concrete;
using BooksApp.Shared.DTOs;
using BooksApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Abstract
{
    public interface IBookService
    {
        #region Generic
        Task<Response<BookDto>> GetByIdAsync(int id);
        Task<Response<List<BookDto>>> GetAllAsync();
        Task<Response<BookDto>> CreateAsync(BookCreateDto bookCreateDto);
        Task<Response<NoContent>> UpdateAsync(BookUpdateDto bookUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        #endregion
        #region Book
        Task<Response<List<BookDto>>> GetBooksWithFullDataAsync(bool? isHome = null, bool? isActive = null);
        Task<Response<List<BookDto>>> GetAllActiveBooksAsync(string categoryUrl = null, string authorUrl = null, string publisherUrl = null);
        Task<Response<BookDto>> GetBookByUrlAsync(string bookUrl);
        Task<Response<BookDto>> GetBookByIdAsync(int id);
        Task<Response<List<BookDto>>> GetBooksByCategoryAsync(int categoryId);
        Task<Response<List<BookDto>>> GetAllBooksWithAuthorAndPublisher(bool isDeleted);

        Task CreateBookAsync(Book book, List<int> SelectedCategoryIds);
        Task UpdateAuthorOfBooks();
        Task UpdatePublisherOfBooks();
        Task CheckBooksCategories();
        void UpdateBook(Book book);
        #endregion
    }
}
