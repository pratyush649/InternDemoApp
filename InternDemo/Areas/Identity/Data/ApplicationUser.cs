﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace InternDemo.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
            [PersonalData]
            [Column(TypeName = "nvarchar(100)")]
            public string FirstName { get; set; }
            [PersonalData]
            [Column(TypeName = "nvarchar(100)")]
            public string MiddleName { get; set; }
            [PersonalData]
            [Column(TypeName = "nvarchar(100)")]
            public string LastName { get; set; }
        public string Fullname
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
     public class ApplicationRole : IdentityRole<int>
    {

    }
}

