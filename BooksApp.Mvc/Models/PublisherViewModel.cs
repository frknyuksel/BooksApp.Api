using System.Text.Json.Serialization;

namespace BooksApp.Mvc.Models
{
    public class PublisherViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        
        [JsonPropertyName("City")]
        public string City { get; set; }
        
        [JsonPropertyName("Country")]
        public string Country { get; set; }
        
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
        
        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }
}
