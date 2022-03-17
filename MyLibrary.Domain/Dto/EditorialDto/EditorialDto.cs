using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiLibrary.Domain.Dto.EditorialDto
{
    public class EditorialDto : InsertEditorialDto
    {
        [Key]
        public int Id { get; set; }

    }
}
