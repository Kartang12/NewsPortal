﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Contracts.V1.Requests
{
    public class UserRgistrationRequest
    {
        public string Email { get; set; }
        public string Password{ get; set; }

    }
}
