using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Shared.DTOs
{
    public class PublisherCreateDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; } = "Türkiye";
        public string Phone { get; set; }
        public string Url { get; set; }
    }
}
