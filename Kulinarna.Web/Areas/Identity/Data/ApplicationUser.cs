﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kulinarna.Web
{
    public class ApplicationUser : IdentityUser
    {
        public String FullName { get; set; }
    }
}
