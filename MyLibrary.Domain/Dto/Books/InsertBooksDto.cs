using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Domain.Dto.Books
{
    public class InsertBooksDto
    {
        public string Title { get; set; }

        [MaxLength(100)]
        public string Gender { get; set; }
        public int Pages { get; set; }
        public string Synopsis { get; set; }
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }

        public int IdTypeState { get; set; }
    }
}
