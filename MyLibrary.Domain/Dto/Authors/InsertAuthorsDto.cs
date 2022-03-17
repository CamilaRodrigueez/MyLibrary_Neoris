using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiLibrary.Domain.Dto.Authors
{
    public class InsertAuthorsDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
