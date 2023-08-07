using System.Text.Json.Serialization;

namespace BooksApp.Mvc.Models
{
    public class BookViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("Stock")]
        public int Stock { get; set; }

        [JsonPropertyName("Price")]
        public double Price { get; set; }

        [JsonPropertyName("PageCount")]
        public int PageCount { get; set; }

        [JsonPropertyName("EditionNumber")]
        public int EditionNumber { get; set; }

        [JsonPropertyName("EditionYear")]
        public int EditionYear { get; set; }

        [JsonPropertyName("Author")]
        public AuthorViewModel Author { get; set; }

        [JsonPropertyName("Publisher")]
        public PublisherViewModel Publisher { get; set; }
    }
}
