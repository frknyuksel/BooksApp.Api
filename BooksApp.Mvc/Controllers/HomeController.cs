using BooksApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace BooksApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            RootList<BookViewModel> rootList  = new RootList<BookViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5201/api/books"))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootList=JsonSerializer.Deserialize<RootList<BookViewModel>>(contentResponse);
                }
            }
            var books = rootList.Data;
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> GetBookById(int id)
        {
            Root<BookViewModel> root = new Root<BookViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5201/api/books/{id}"))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllBooks");
                    }
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    root = JsonSerializer.Deserialize<Root<BookViewModel>>(contentResponse);
                }
            }
            var book = root.Data;
            return View(book);
        }

        //Publisher'lar için aynı işlemleri yapın.
    }
}