using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Domain.Dto.Books
{
    public class ConsultBooksDto : BooksDto
    {
        public string Title { get; set; }

        [MaxLength(100)]
        public string Gender { get; set; }
        public int Pages { get; set; }

        [MaxLength(100)]
        public string TypeState { get; set; }

        [MaxLength(100)]
        public string Editorial { get; set; }

        [MaxLength(100)]
        public string Direction { get; set; }

        public string NameAuthor { get; set; }
        public string Synopsis { get; set; }

    }
}
