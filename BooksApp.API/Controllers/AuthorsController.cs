using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BooksApp.Business.Abstract;
using BooksApp.Business.Concrete;
using BooksApp.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : CustomControllerBase
    {
        private readonly IAuthorService _authorManager;

        public AuthorsController(IAuthorService authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var response = await _authorManager.GetAllAsync();
            return CreateActionResult(response);
        }
    }
}

