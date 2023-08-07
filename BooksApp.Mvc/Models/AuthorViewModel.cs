using System.Text.Json.Serialization;

namespace BooksApp.Mvc.Models
{
    public class AuthorViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("BirthOfYear")]
        public int BirthOfYear { get; set; }
        
        [JsonPropertyName("IsAlive")]
        public bool IsAlive { get; set; }
        
        [JsonPropertyName("Url")]
        public string Url { get; set; }
        
        [JsonPropertyName("About")]
        public string About { get; set; }
        
        [JsonPropertyName("PhotoUrl")]
        public string PhotoUrl { get; set; }
    }
}
