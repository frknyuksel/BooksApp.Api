using System;
namespace BooksApp.Shared.DTOs
{
	public class BookCategoryDto
	{
        public int BookId { get; set; }
        public BookDto Book { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}

