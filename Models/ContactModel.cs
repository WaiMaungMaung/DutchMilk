﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DutchMilk.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email {get; set;}
        [Required]
        public string Subject { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Short msg")]
        public string Message { get; set; }

    }
}
