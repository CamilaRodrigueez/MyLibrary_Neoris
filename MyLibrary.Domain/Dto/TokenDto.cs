﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Domain.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public double Expiration { get; set; }
    }
}
