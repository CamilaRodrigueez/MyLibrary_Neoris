﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Domain.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
