using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Domain.Dto.Books
{
    public class BooksDto : InsertBooksDto
    {
      [Key]
        public int Id { get; set; }

    }
}
