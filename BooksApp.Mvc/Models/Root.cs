using System.Text.Json.Serialization;

namespace BooksApp.Mvc.Models
{
    public class Root<T>
    {
        [JsonPropertyName("Data")]
        public T Data { get; set; }

        [JsonPropertyName("Errors")]
        public List<string> Errors { get; set; }
    }
}
