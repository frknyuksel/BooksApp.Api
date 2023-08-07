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
    public interface IPublisherService
    {
        #region Generic
        Task<Response<PublisherDto>> GetByIdAsync(int? id);
        Task<Response<List<PublisherDto>>> GetAllAsync();
        Task<Response<PublisherDto>> CreateAsync(PublisherCreateDto publisherCreateDto);
        Task<Response<NoContent>> UpdateAsync(PublisherDto publisherDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        #endregion
    }
}
