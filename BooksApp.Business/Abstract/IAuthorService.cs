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
    public interface IAuthorService
    {
        #region Generic
        Task<Author> GetByIdAsync(int? id);
        Task<Response<List<AuthorDto>>> GetAllAsync();
        Task CreateAsync(Author author);
        void Update(Author author);
        void Delete(Author author);
        #endregion
        #region Author
        Task<List<Author>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Author author);
        #endregion
    }
}
