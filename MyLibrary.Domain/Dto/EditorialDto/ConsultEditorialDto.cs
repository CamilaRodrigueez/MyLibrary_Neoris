using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiLibrary.Domain.Dto.EditorialDto
{
    public class ConsultEditorialDto : EditorialDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Direction { get; set; }
    }
}
