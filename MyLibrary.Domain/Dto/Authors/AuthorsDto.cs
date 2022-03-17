using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiLibrary.Domain.Dto.Authors
{
    public class AuthorsDto : InsertAuthorsDto
    {
        [Key]
        public int Id { get; set; }

        
    }
}
