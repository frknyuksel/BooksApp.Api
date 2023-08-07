using BooksApp.Business.Abstract;
using BooksApp.Shared.ControllerBases;
using BooksApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BooksApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CustomControllerBase
    {
        private readonly IBookService _bookManager;

        public BooksController(IBookService bookManager)
        {
            _bookManager = bookManager;
        }
        //http://localhost:5201/api/books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookManager.GetBooksWithFullDataAsync(null,true);
            return CreateActionResult(response);
        }
        //http://localhost:5201/api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _bookManager.GetBookByIdAsync(id);
            return CreateActionResult(response);
        }
        [HttpPost]
        [Route("/api/[controller]/SaveBook")]
        public async Task<IActionResult> SaveBook(BookCreateDto bookCreateDto)
        {
            var response = await _bookManager.CreateAsync(bookCreateDto);
            return CreateActionResult(response);
        }
        //http://localhost:5201/api/books/getbooksbycategory/5
        [HttpGet]
        [Route("/api/[controller]/GetBooksByCategory/{categoryId}")]
        public async Task<IActionResult> GetBooksByCategory(int categoryId)
        {
            var response = await _bookManager.GetBooksByCategoryAsync(categoryId);
            return CreateActionResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookUpdateDto bookUpdateDto)
        {
            var response = await _bookManager.UpdateAsync(bookUpdateDto);
            return CreateActionResult(response);
        }
    }
}
