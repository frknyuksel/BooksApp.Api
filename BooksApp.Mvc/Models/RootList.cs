using System.Text.Json.Serialization;

namespace BooksApp.Mvc.Models
{
    public class RootList<T>
    {
        [JsonPropertyName("Data")]
        public List<T> Data { get; set; }

        [JsonPropertyName("Errors")]
        public List<string> Errors { get; set; }
    }
}
