using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("AuthorsBooks", Schema = "Library")]
    public class AuthorbooksEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuthorsEntity")]
        public int IdAuthor { get; set; }
        public AuthorsEntity AuthorsEntity { get; set; }

        [ForeignKey("BooksEntity")]
        public int IdBooks { get; set; }
        public BooksEntity BooksEntity { get; set; }
    }
}
