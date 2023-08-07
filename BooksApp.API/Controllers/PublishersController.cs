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
    public class PublishersController : CustomControllerBase
    {
        private readonly IPublisherService _publisherManager;

        public PublishersController(IPublisherService publisherManager)
        {
            _publisherManager = publisherManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _publisherManager.GetAllAsync();
            if (response.IsSucceeded)
            {
                var jsonResult = JsonSerializer.Serialize(response);
                return Ok(jsonResult);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _publisherManager.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                var jsonResult = JsonSerializer.Serialize(response);
                return Ok(jsonResult);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Save(PublisherCreateDto publisherCreateDto)
        {
            var response = await _publisherManager.CreateAsync(publisherCreateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(PublisherDto publisherDto)
        {
            var response = await _publisherManager.UpdateAsync(publisherDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _publisherManager.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
    }
}
