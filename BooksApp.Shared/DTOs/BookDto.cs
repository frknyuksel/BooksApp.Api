using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksApp.Shared.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public int EditionNumber { get; set; }
        public int EditionYear { get; set; }
        public bool IsHome { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
