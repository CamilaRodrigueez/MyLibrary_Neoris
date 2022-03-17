using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Domain.Dto
{
    public class TypeStateDto
    {
            public int IdTypeState { get; set; }

            [MaxLength(100)]
            public string TypeState { get; set; }
        
    }
}
